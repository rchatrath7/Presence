using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DiscreteButton : Button {

    public Material matActiveBar;
    public Material matInactiveBar;

    // Automate this part
    [Header("GameObjects Used")]
    public GameObject activeBar; 
    public GameObject mainBar;

    protected Renderer rendActiveBar;

    protected override void Start()
    {
        base.Start();
        rend = mainBar.GetComponent<Renderer>();
        rend.sharedMaterial.color = colorBackground;
        rendActiveBar = activeBar.GetComponent<Renderer>();
    }

    protected override void Update()
    {
        base.Update();
        rendActiveBar.material = (isActive) ? matActiveBar : matInactiveBar;
    }

    public override void AnimateOnClick()
    {
        base.AnimateOnClick();
        isActive = !isActive;
    }

}
