using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class IconButton : Button {

    [Header("GameObjects Used")]
    public GameObject icon;
    public GameObject label;
    public GameObject background;

    protected override void Start()
    {
        base.Start();
        rend = background.GetComponent<Renderer>();
        rend.sharedMaterial.color = colorBackground;
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void AnimateOnClick()
    {
        anim.SetBool("Clicked", true);
        Debug.Log("Clicked");
        isActive = !isActive;
    }

    public override void AnimateOnGazeEnter()
    {
        anim.SetBool("Clicked", false);
        anim.SetBool("Hovering", true);
        Debug.Log("Gaze started");
    }

    public override void AnimateOnGazeExit()
    {
        anim.SetBool("Hovering", false);
        Debug.Log("Gaze ended");
    }

}
