using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{

    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/ScriptReference/Animator.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    Animator animatorController;  

    string state;
    float pauseFrame;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetAGEUKE()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 1.00f);
        state = "Base Layer.AGE-UKE";
        pauseFrame = 24.0f/64.0f;
        animatorController.Play(state);
    }

    public void SetGEDANBARAI()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 1.00f);
        state = "Base Layer.GEDAN-BARAI";
        pauseFrame = 20.0f/66.0f;
        animatorController.Play(state);
    }

    public void SetSOTOUKE()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 1.00f);
        state = "Base Layer.SOTO-UKE";
        pauseFrame = 20.0f/53.0f;
        animatorController.Play(state);
    }

    public void SetUCHIUKE()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 1.00f);
        state = "Base Layer.UCHI-UKE";
        pauseFrame = 19.0f/45.0f;
        animatorController.Play(state);
    }

    //-------------------------------------------------------------


    // playback speed button functions
    //-------------------------------------------------------------

    public void Set001()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.01f);
    }

    public void Set005()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.05f);
    }

    public void Set010()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.10f);
    }

    public void Set015()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.15f);
    }

    public void Set020()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.20f);
    }
    
    public void Set025()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.25f);
    }

    public void Set050()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.50f);
    }

    public void Set075()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 0.75f);
    }

    public void Set100()
    {
        animatorController.speed = 1;
        animatorController.SetFloat("speedMultiplier", 1.00f);
    }

    //-------------------------------------------------------------


    // lead hand button functions
    //-------------------------------------------------------------

    public void SetLeft()
    {
        animatorController.speed = 1;
        animatorController.SetBool("mirrored", false);
    }

    public void SetRight()
    {
        animatorController.speed = 1;
        animatorController.SetBool("mirrored", true);
    }

    //-------------------------------------------------------------


    // pause button functions
    //-------------------------------------------------------------

    public void pauseAtFrame()
    {
        animatorController.Play(state, -1, pauseFrame);
        animatorController.speed = 0;
    }

    public void keepPlaying()
    {
        animatorController.speed = 1;
    }

    //-------------------------------------------------------------

}
