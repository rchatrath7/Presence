from .models import FacebookProfile


def save_profile(backend, user, response, *args, **kwargs):
    FacebookProfile.objects.create(
        user=user,
        access_token=user.social_auth.get(provider='facebook').extra_data['access_token']
    )
