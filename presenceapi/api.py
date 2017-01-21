from presenceapi.models import FacebookProfile
from presenceapi.serializers import FacebookProfileSerializer

from rest_framework import generics


class FacebookProfileList(generics.ListCreateAPIView):
    """
    List all Facebook profiles or create a new profile
    """
    queryset = FacebookProfile.objects.all()
    serializer_class = FacebookProfileSerializer


class FacebookProfileDetails(generics.RetrieveAPIView):
    """
    Retrieve a specific Facebook Profile
    """
    queryset = FacebookProfile.objects.all()
    serializer_class = FacebookProfileSerializer
