using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILineManager : MonoBehaviour {

	private LineRenderer lineRend;

	public GameObject personalUI;

	private Vector3[] linePositions;

	// Use this for initialization
	void Start () {
		lineRend = GetComponent<LineRenderer> ();
		lineRend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (personalUI.activeSelf) {

			// Reset Vector3 array
			linePositions = new Vector3[3];
			lineRend.enabled = true;

			int count = 0;

			// Get all endpoints and put their positions in the array
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("LineEndpoint")) {
				linePositions [count] = go.transform.position;
				count++;
			}
				
			// Update the line renderer
			lineRend.SetPositions (linePositions);

		} else {
			lineRend.enabled = false;
		}
	}
}
