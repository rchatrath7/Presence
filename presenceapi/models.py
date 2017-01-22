from __future__ import unicode_literals

from django.contrib.postgres.fields import JSONField
from django.db import models

from django.db.models.signals import post_save
from django.dispatch import receiver
from rest_framework.authtoken.models import Token
from django.conf import settings

# Create your models here.
# Rudimentary Profile Model
class FacebookProfile(models.Model):
    user = models.OneToOneField('auth.User', on_delete=models.CASCADE, null=True)
    access_token = models.CharField(max_length=255)
    profile_picture = models.URLField(max_length=255, null=True)
    likes = JSONField(null=True)
    tagged_places = JSONField(null=True)
    posts = JSONField(null=True)
    personality = JSONField(null=True)
    # birthday = JSONField()
    # hometown = JSONField()
    # work_history = JSONField()


# This code is triggered whenever a new user has been created and saved to the database

@receiver(post_save, sender=settings.AUTH_USER_MODEL)
def create_auth_token(sender, instance=None, created=False, **kwargs):
    if created:
        Token.objects.create(user=instance)
