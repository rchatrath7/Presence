from presenceapi.models import FacebookProfile
from presenceapi.serializers import FacebookProfileSerializer

from watson_developer_cloud import AlchemyLanguageV1, PersonalityInsightsV3

import json

from django.http import Http404
from django.conf import settings

from rest_framework import generics
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import status

alchemy = AlchemyLanguageV1(api_key=settings.WATSON_API_KEY)
personality = PersonalityInsightsV3(version=settings.WATSON_VERSION,
                                    username=settings.WATSON_USERNAME,
                                    password=settings.WATSON_PASSWORD)

def _get_top_attr(details):
    max_score = 0
    category = details[0]['category']
    name = ""

    for i in details:
        if i['percentile'] * 100 / i['raw_score'] > max_score:
            name = i["name"]
            max_score = i['percentile'] * 100 / i['raw_score']

    return [category, name]

def _get_top_attr_with_children(details):
    _top_attr = _get_top_attr(details)
    _specific = _get_top_attr(filter(lambda x: x['name'] == _top_attr[1], details)[0]["children"])[1]

    return [_top_attr[0], _top_attr[1] + " (" + _specific + ")"]


class FacebookProfileList(generics.ListCreateAPIView):
    """
    List all Facebook profiles or create a new profile
    """
    queryset = FacebookProfile.objects.all()
    serializer_class = FacebookProfileSerializer


class FacebookProfileDetails(APIView):
    """
    Retrieve a specific Facebook Profile
    """

    def get_object(self, pk):
       try:
           return FacebookProfile.objects.get(user_id=pk)
       except FacebookProfile.DoesNotExist:
           raise Http404

    def get(self, request, pk, format=None):
        user = FacebookProfile.objects.get(user_id=request.user.id)
        profile = self.get_object(pk)
        serializer = FacebookProfileSerializer(profile)
        _user_feed = '' + json.dumps(user.likes)
        _profile_feed = '' + json.dumps(profile.likes)
        _profile_posts = ' '.encode('utf-8')

        for i in profile.posts["data"]:
            if "message" in i:
                _profile_posts += i["message"].encode('utf-8') + " "

        suggestions = alchemy.combined(text=_user_feed+_profile_feed, extract='keywords')
        _suggest = []

        for word in suggestions['keywords']:
            if word['text'] not in _user_feed:
                _suggest.append(word['text'])

        if profile.personality:
            profile_personality = profile.personality
        else:
            profile_personality = personality.profile(_profile_posts,
                                                     content_type='text/plain',
                                                     raw_scores=True,
                                                     consumption_preferences=True
                                                     )
            _need = _get_top_attr(profile_personality["needs"])
            _value = _get_top_attr(profile_personality["values"])
            _personality = _get_top_attr_with_children(profile_personality["personality"])

            profile_personality = {
                _need[0]: _need[1],
                _value[0]: _value[1],
                _personality[0]: _personality[1]
            }

            profile.personality = profile_personality
            profile.save()

        return Response({'user': serializer.data, 'suggestions': _suggest, 'personality': profile_personality})
        # return Response({'post': _profile_posts})
