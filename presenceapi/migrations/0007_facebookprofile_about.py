# -*- coding: utf-8 -*-
# Generated by Django 1.10.5 on 2017-01-22 04:51
from __future__ import unicode_literals

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('presenceapi', '0006_facebookprofile_profile_picture'),
    ]

    operations = [
        migrations.AddField(
            model_name='facebookprofile',
            name='about',
            field=models.CharField(max_length=255, null=True),
        ),
    ]
