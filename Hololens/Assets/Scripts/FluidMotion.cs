using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FluidMotion : MonoBehaviour {

    private LineRenderer lineRenderer;
    public Material whiteFlicker;
    
    private void Update()
    {
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(1, transform.parent.transform.parent.position);
            lineRenderer.material = whiteFlicker;
        }

        if(lineRenderer.enabled)
        {
            lineRenderer.SetPosition(0, transform.position);
        }
    }

    void Flicker()
    {
        whiteFlicker.SetColor("Albedo", new Color(1f, 1f, 1f, Random.Range(0, 1f)));
    }

}
