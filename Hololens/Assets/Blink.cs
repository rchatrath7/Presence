using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

    public GameObject recordingLight;

	// Use this for initialization
	void Start () {
        StartCoroutine("Recording");
        recordingLight.SetActive(false);
    }

    IEnumerator Recording()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);
            recordingLight.SetActive(!recordingLight.activeSelf);
        }
    }
}
