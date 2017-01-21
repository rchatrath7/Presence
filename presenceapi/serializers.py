# Serializers
from rest_framework import serializers

# Models
from presenceapi.models import FacebookProfile

class FacebookProfileSerializer(serializers.ModelSerializer):
    class Meta:
        model = FacebookProfile
        fields = (
            "id",
            "first_name",
            "last_name",
            "access_token",
            "profile_picture"
        )
