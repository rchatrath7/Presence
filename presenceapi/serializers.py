# Serializers
from rest_framework import serializers

# Models
from presenceapi.models import FacebookProfile

class FacebookProfileSerializer(serializers.ModelSerializer):
    first_name = serializers.CharField(source='user.first_name')
    last_name = serializers.CharField(source='user.first_name')

    class Meta:
        model = FacebookProfile
        fields = (
            "id",
            "first_name",
            "last_name",
            "access_token"
        )
