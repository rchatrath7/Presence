using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject prefabObject;

    public void Spawn()
    {
        
        Instantiate(prefabObject, transform.position + new Vector3(0, 0, 0.1f), Quaternion.identity);
    }
}
