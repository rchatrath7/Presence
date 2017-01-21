from rest_framework.authtoken.views import ObtainAuthToken
from rest_framework.authtoken.models import Token
from rest_framework.response import Response

class ObtainAuthTokenAndUser(ObtainAuthToken):
    """
    Custom Auth Token class to return a User ID alongside they're custom
    token.
    """

    def post(self, request, *args, **kwargs):
        serializer = self.serializer_class(data=request.data)
        serializer.is_valid(raise_exception=True)
        user = serializer.validated_data['user']
        token, created = Token.objects.get_or_create(user=user)
        return Response({'token': token.key, 'id': user.id})

obtain_auth_token_and_user = ObtainAuthTokenAndUser.as_view()
