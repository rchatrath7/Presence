# -*- coding: utf-8 -*-
# Generated by Django 1.10.5 on 2017-01-22 02:09
from __future__ import unicode_literals

import django.contrib.postgres.fields.jsonb
from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('presenceapi', '0004_facebookprofile_personality'),
    ]

    operations = [
        migrations.AddField(
            model_name='facebookprofile',
            name='posts',
            field=django.contrib.postgres.fields.jsonb.JSONField(null=True),
        ),
    ]