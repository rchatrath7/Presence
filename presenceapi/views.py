from django.contrib.auth.decorators import login_required
from django.contrib import messages

from django.shortcuts import render, redirect

# Create your views here.

def root(request):
    return render(request, 'root.html')

def home(request):
    if request.method == 'POST':
        password1 = request.POST['password1']
        password2 = request.POST['password2']

        if password1 == password2:
            request.user.set_password(password1)
            request.user.save()
            messages.success(request, "Success! You've set your password")
        else:
            messages.error(request, "Uh oh! Your passwords do not match")

    return render(request, 'home.html')

def go_to_facebook(request):
    return redirect(request, "login/facebook/")
