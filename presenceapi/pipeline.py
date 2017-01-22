from .models import FacebookProfile

import facebook


def save_profile(backend, user, response, *args, **kwargs):
    token = user.social_auth.get(provider='facebook').extra_data['access_token']
    graph = facebook.GraphAPI(token)

    FacebookProfile.objects.create(
        user=user,
        access_token=token,
        likes=graph.get_connections(
            id='me',
            connection_name='likes',
            since='2014-11-1',
            until='2017-1-20',
            limit=1000
        ),
        tagged_places=graph.get_connections(
            id='me',
            connection_name='tagged_places',
            since='2014-11-1',
            until='2017-1-20',
            limit=1000
        ),
        posts=graph.get_connections(
            id='me',
            connection_name='posts',
            since='2014-11-1',
            until='2017-1-20',
            limit=1000
        ),
    )
