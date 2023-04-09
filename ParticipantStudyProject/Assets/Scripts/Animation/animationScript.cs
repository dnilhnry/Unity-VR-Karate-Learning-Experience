using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animationScript : MonoBehaviour
{

    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/ScriptReference/GameObject.html
    // https://docs.unity3d.com/ScriptReference/UIElements.Slider.html
    // https://docs.unity3d.com/ScriptReference/Animator.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    [SerializeField] private GameObject character;
    Animator animatorController;
    [SerializeField] private Slider height_Slider;
    [SerializeField] private Text height_Text;

    float defaultHeight = 177.0f;
    float heightMultiplier;
    string state;
    float pauseFrame;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    //-------------------------------------------------------------


    // set character height
    //-------------------------------------------------------------

    public void SetHeight()
    {
        heightMultiplier = height_Slider.value/defaultHeight;
        character.transform.localScale = new Vector3(0.75f + heightMultiplier/4,heightMultiplier,0.75f + heightMultiplier/4);
        height_Text.text = height_Slider.value.ToString("0") +  " cm";
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
        animatorController.SetFloat("offset", 0.00f);
    }

    public void SetRight()
    {
        animatorController.speed = 1;
        animatorController.SetBool("mirrored", true);
        animatorController.SetFloat("offset", 0.50f);
    }

    //-------------------------------------------------------------


    // pause button functions
    //-------------------------------------------------------------

    public void Pause()
    {
        animatorController.Play(state, -1, pauseFrame);
        animatorController.speed = 0;
    }

    public void Resume()
    {
        animatorController.speed = 1;
    }

    //-------------------------------------------------------------

}
