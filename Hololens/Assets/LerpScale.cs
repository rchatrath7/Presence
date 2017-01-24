using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpScale : MonoBehaviour {

    public float maxScale;
    public float minScale;
    public float lerpTime;

    private bool reverse = false;

    private void Start()
    {
        reverse = false;
    }

    // Update is called once per frame
    void Update () {
        
    }
}
