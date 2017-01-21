from django.conf.urls import url
from rest_framework.urlpatterns import format_suffix_patterns
from . import views

urlpatterns = [
    url(r'^api/users/$', views.FacebookProfileList.as_view()),
    url(r'^api/users/(?P<pk>[0-9]+)/$', views.FacebookProfileDetails.as_view()),
]

urlpatterns = format_suffix_patterns(urlpatterns)
