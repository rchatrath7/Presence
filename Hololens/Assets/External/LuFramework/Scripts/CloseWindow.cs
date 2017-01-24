using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWindow : MonoBehaviour {

	public void delete(GameObject go) {
		Destroy (go);
	}

	public void hide(GameObject go) {
		go.SetActive (false);
	}

}
