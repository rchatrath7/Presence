using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public abstract class Button : MonoBehaviour
{
    [Header("Animation Properties")]
    public float animationSpeed;
    protected Animator anim;
    protected Renderer rend;

    [Header("Button Info")]
    public GameObject label;
    public string labelString;

    [Header("Colors and Materials")]
    public Color colorBackground;

    protected bool isActive = false;

    protected virtual void Start()
    {
        // Setting up the animator of the button
        anim = GetComponent<Animator>();
        anim.SetFloat("Speed", animationSpeed);

        if (label != null)
            label.GetComponent<TextMesh>().text = labelString;
    }

    protected virtual void Update()
    {
        // Update
    }

    /* ANIMATIONS shared by all buttons
     * If you want to modify anything, just override the method and call the function from the base class
    */

    public virtual void AnimateOnGazeEnter()
    {
        anim.SetBool("Hovering", true);
        Debug.Log("User looked at " + gameObject.name);
    }

    public virtual void AnimateOnGazeExit()
    {
        anim.SetBool("Hovering", false);
    }

    public virtual void AnimateOnClick()
    {
        anim.SetTrigger("Clicked");
        Debug.Log("User clicked on " + gameObject.name);
    }

}