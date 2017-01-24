using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalUIManager : MonoBehaviour {

	void Start() {
		gameObject.SetActive (false);
	}

	public void OnGazeExit() {
		gameObject.SetActive (false);
	}

}
