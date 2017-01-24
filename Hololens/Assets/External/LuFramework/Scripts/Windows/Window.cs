using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
// This class contains all main functionality that is shared amongst windows

[ExecuteInEditMode]
public abstract class Window : MonoBehaviour {

    [Header("Window Info")]
    public GameObject labelGO;
    public string labelString;
    public List<GameObject> buttons;
    public GameObject content;

    protected virtual void Start()
    {
        buttons = new List<GameObject>();
        labelGO.GetComponent<TextMesh>().text = labelString;
    }

}
