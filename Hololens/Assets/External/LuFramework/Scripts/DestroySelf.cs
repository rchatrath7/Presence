using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {

    public GameObject target;

	public void DestroyMe()
    {
        Destroy(target);
    }

}
