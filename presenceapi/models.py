from __future__ import unicode_literals

from django.db import models

# Create your models here.
# Rudimentary Profile Model
class FacebookProfile(models.Model):
    first_name = models.CharField(max_length=100)
    last_name = models.CharField(max_length=100)
    user_name = models.CharField(max_length=100)
    profile_picture = models.CharField(max_length=100)
    access_token = models.CharField(max_length=100)
