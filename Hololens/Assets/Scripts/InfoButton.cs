using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour {

    public GameObject centerButton;
    public GameObject otherButton;
    public GameObject thirdButton;

    public Material returnButton;
    public Material defaultMaterial;
    public GameObject icon;

    private Vector3 originalPosition;
    public bool isActive = false;

    private void Start()
    {
        originalPosition = transform.position;
        isActive = false;
    }

    public void OnClick()
    {
        if(!isActive)
        {
            originalPosition = transform.position;
            centerButton.SetActive(false);
            otherButton.SetActive(false);
            thirdButton.SetActive(false);
            originalPosition = transform.position;
            icon.GetComponent<Renderer>().material = returnButton;
            isActive = true;
        } else
        {
            centerButton.SetActive(true);
            otherButton.SetActive(true);
            thirdButton.SetActive(true);
            icon.GetComponent<Renderer>().material = defaultMaterial;
            originalPosition = transform.position;
            isActive = false;
        }
    }

    private void Update()
    {
        /*if(isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerButton.transform.position, 0.05f * Time.deltaTime);
        }*/
    }

}
