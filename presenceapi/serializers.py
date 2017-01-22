# Serializers
from rest_framework import serializers

# Models
from presenceapi.models import FacebookProfile


class JSONSerializerField(serializers.Field):
    """ Serializer for JSONField -- required to make field writable"""

    def to_internal_value(self, data):
        return data
    def to_representation(self, value):
        return value


class FacebookProfileSerializer(serializers.ModelSerializer):
    first_name = serializers.CharField(source='user.first_name')
    last_name = serializers.CharField(source='user.first_name')

    class Meta:
        model = FacebookProfile
        fields = (
            "id",
            "first_name",
            "last_name",
            "access_token",
            "profile_picture",
        )
