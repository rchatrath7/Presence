from presenceapi.models import FacebookProfile
from presenceapi.serializers import FacebookProfileSerializer
from django.http import Http404
from rest_framework.views import APIView
from rest_framework.response import Response
from rest_framework import status

# Create your views here.
class FacebookProfileList(APIView):
    """
    List all Facebook profiles or create a new profile
    """
    def get(self, request, format=None):
        facebook_profiles = FacebookProfile.objects.all()
        serializer = FacebookProfileSerializer(facebook_profiles, many=True)
        return Response(serializer.data)

    def post(self, request, format=None):
        serializer = FacebookProfileSerializer(data=request.data)
        if serializer.is_valid():
            serializer.save()
            return Response(serializer.data, status=status.HTTP_201_CREATED)
        return Response(serializer.errors, status=status.HTTP_400_BAD_REQUEST)

class FacebookProfileDetails(APIView):
    """
    Retrieve a specific Facebook Profile
    """
    def get_object(self, pk):
        try:
            return FacebookProfile.objects.get(pk=pk)
        except FacebookProfile.DoesNotExist:
            raise Http404

    def get(self, request, pk, format=None):
        facebook_profile = self.get_object(pk)
        serializer = FacebookProfileSerializer(facebook_profile)
        return Response(serializer.data)
