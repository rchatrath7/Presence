using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour {

    public GameObject[] prefabs;

    public void Spawn()
    {
        foreach(GameObject prefab in prefabs)
        {
            Instantiate(prefab, Camera.main.transform.position + (Camera.main.transform.forward * 0.7f), Camera.main.transform.rotation);
        }
    }

    public void ToggleSetActive()
    {
        foreach(GameObject prefab in prefabs)
        {
            prefab.SetActive(!prefab.activeSelf);
        }
    }
}
