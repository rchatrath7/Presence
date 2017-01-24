using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RadialMenuButton : Button {

    // Automate this part
    [Header("GameObjects Used")]
    public GameObject background;
    public GameObject icon;

    protected override void Start()
    {
        base.Start();
        rend = background.GetComponent<Renderer>();
    }

    protected override void Update()
    {
        base.Update();
    }

}
