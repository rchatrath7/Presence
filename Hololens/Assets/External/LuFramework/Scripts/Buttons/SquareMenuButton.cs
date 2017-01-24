using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareMenuButton : Button {

    public GameObject outline;
    public GameObject geometry;
    public static float fadeTime = 0.5f;
    
    private void Start()
    {
        base.Start();
        outline.SetActive(false);
        StartCoroutine(FadeTo(0f, fadeTime));
        rend = geometry.GetComponent<Renderer>();
    }

    public void OnGazeEnter()
    {
        outline.SetActive(true);
        // StartCoroutine(FadeTo(1f, fadeTime));
    }

    public void OnGazeExit()
    {
        outline.SetActive(false);
        // StartCoroutine(FadeTo(0f, fadeTime));
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = outline.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            outline.GetComponent<Renderer>().sharedMaterial.color = newColor;
            yield return null;
        }
    }

}
