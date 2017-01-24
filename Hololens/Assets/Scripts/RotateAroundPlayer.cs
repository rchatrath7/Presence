using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPlayer : MonoBehaviour {

    public float angle;

    void Update()
    {
        transform.RotateAround(Camera.main.transform.position, Vector3.up, angle * Time.deltaTime);
    }
}
