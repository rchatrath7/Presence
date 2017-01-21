from __future__ import unicode_literals

from django.contrib.postgres.fields import JSONField
from django.db import models

# Create your models here.
# Rudimentary Profile Model
class FacebookProfile(models.Model):
    user = models.OneToOneField('auth.User', on_delete=models.CASCADE, null=True)
    access_token = models.CharField(max_length=255)
    likes = JSONField()
    tagged_places = JSONField()
    # birthday = JSONField()
    # hometown = JSONField()
    # work_history = JSONField()
