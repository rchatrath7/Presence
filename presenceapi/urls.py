from django.conf.urls import url
from rest_framework.urlpatterns import format_suffix_patterns
from . import _token_view, api

urlpatterns = [
    url(r'^api/users/$', api.FacebookProfileList.as_view()),
    url(r'^api/users/(?P<pk>[0-9]+)/$', api.FacebookProfileDetails.as_view()),
    url(r'^api/session/', _token_view.obtain_auth_token_and_user),
]

urlpatterns = format_suffix_patterns(urlpatterns)
