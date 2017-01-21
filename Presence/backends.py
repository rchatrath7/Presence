from social_core.backends.facebook import FacebookOAuth2

class CustomFacebookOAuth2(FacebookOAuth2):
    def get_scope(self):
        scope = super(CustomFacebookOAuth2, self).get_scope()
        # scope += [
        #     'email', 'user_friends', 'user_birthday', 'user_hometown',
        #     'user_likes', 'user_location', 'user_photos', 'user_relationships',
        #     'user_tagged_places', 'user_work_history'
        # ]
        scope += ['user_likes', 'user_tagged_places']
        return scope
