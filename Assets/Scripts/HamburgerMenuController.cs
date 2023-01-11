using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamburgerMenuController : MonoBehaviour
{
    public GameObject hamburger;
    public GameObject optionsUI;
    public bool stopDraw;

    public void setHamburgerVisible()
    {
        Animator animator = hamburger.GetComponent<Animator>();
        bool isVisible = animator.GetBool("Visible");
        //Debug.Log(isVisible);
        optionsUI.SetActive(!isVisible);
        animator.SetBool("Visible", !isVisible);
    }
}