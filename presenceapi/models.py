from __future__ import unicode_literals

from django.db import models

# Create your models here.
# Rudimentary Profile Model
class FacebookProfile(models.Model):
    user = models.OneToOneField('auth.User', on_delete=models.CASCADE, null=True)
    access_token = models.CharField(max_length=255)
