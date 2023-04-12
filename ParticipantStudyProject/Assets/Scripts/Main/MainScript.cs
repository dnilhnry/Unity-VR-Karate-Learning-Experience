using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{

    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/ScriptReference/GameObject.html
    // https://docs.unity3d.com/ScriptReference/UIElements.Slider.html
    // https://docs.unity3d.com/ScriptReference/Animator.html
    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Text.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject MiniMenuPanel;
    [SerializeField] private GameObject character;
    Animator animatorController;
    [SerializeField] private GameObject ToolsPanel;
    [SerializeField] private Slider height_Slider;
    [SerializeField] private Text height_Text;
    [SerializeField] private GameObject InfoPanel;
    [SerializeField] private Text Name;
    [SerializeField] private Text Description;

    float defaultHeight = 177.0f;
    float heightMultiplier;
    string state;
    float pauseFrame;

    void Start()
    {
        animatorController = GetComponent<Animator>();
        Reset();
    }

    //-------------------------------------------------------------


    // menu functions
    //-------------------------------------------------------------

    public void MenuOpen()
    {
        MenuPanel.SetActive(true);
        MiniMenuPanel.SetActive(false);
        ToolsPanel.SetActive(false);
        InfoPanel.SetActive(false);
    }

    public void MenuClose()
    {
        MenuPanel.SetActive(false);
        MiniMenuPanel.SetActive(true);
        ToolsPanel.SetActive(true);
        InfoPanel.SetActive(false);
    }

    public void Reset()
    {
        MenuOpen();
        SetDefaultHeight();
        SetIDLE();
        SetLeft();
    }

    public void Quit()
    {
        Application.Quit();
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

    public void SetDefaultHeight()
    {
        height_Slider.value = defaultHeight;
        character.transform.localScale = new Vector3(1, 1, 1);
        height_Text.text = height_Slider.value.ToString("0") +  " cm";
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetIDLE()
    {
        state = "Base Layer.Idle";
        pauseFrame = 0;
        animatorController.Play(state, -1, 0);
        Set100();

        Name.text = "Heiko-Dachi";
        Description.text = "Heiko-Dachi translates to 'parallel stance' in English. \n\n";
        Description.text = Description.text + "This stance is used during every technique throughout this application. \n\n";
        Description.text = Description.text + "The use of this stance is uncommon in practical Karate, fighting with your feet parallel is not an ideal stance. This stance is useful while learning new techniques, it allows the student to focus on correct arm placement / movement. \n";

        Resume();
    }

    public void SetAGEUKE()
    {
        state = "Base Layer.AGE-UKE";
        pauseFrame = 24.0f/64.0f;
        animatorController.Play(state, -1, 0);
        Set100();

        state = "Base Layer.AGE-UKE";
        Name.text = "Age-Uke";
        Description.text = "Age-Uke translates to 'rising block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your head. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack is positioned above your head. \n";

        Resume();
    }

    public void SetGEDANBARAI()
    {
        state = "Base Layer.GEDAN-BARAI";
        pauseFrame = 20.0f/66.0f;
        animatorController.Play(state, -1, 0);
        Set100();

        Name.text = "Gedan-Barai";
        Description.text = "Gedan-Barai translates to 'low block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your lower body. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack is positioned far to the side of your body. \n";

        Resume();
    }

    public void SetSOTOUKE()
    {
        state = "Base Layer.SOTO-UKE";
        pauseFrame = 20.0f/53.0f;
        animatorController.Play(state, -1, 0);
        Set100();

        Name.text = "Soto-Uke";
        Description.text = "Soto-Uke translates to 'outer block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your chest. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack comes all the way across your body. \n";

        Resume();
    }

    public void SetUCHIUKE()
    {
        state = "Base Layer.UCHI-UKE";
        pauseFrame = 19.0f/45.0f;
        animatorController.Play(state, -1, 0);
        Set100();

        Name.text = "Uchi-Uke";
        Description.text = "Uchi-Uke translates to 'inner block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your chest. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack comes from the inside, across your body. \n";

        Resume();
    }

    //-------------------------------------------------------------


    // playback speed button functions
    //-------------------------------------------------------------

    public void Set005()
    {
        animatorController.SetFloat("speedMultiplier", 0.05f);
        Resume();
    }

    public void Set010()
    {
        animatorController.SetFloat("speedMultiplier", 0.10f);
        Resume();
    }

    public void Set015()
    {
        animatorController.SetFloat("speedMultiplier", 0.15f);
        Resume();
    }

    public void Set020()
    {
        animatorController.SetFloat("speedMultiplier", 0.20f);
        Resume();
    }
    
    public void Set025()
    {
        animatorController.SetFloat("speedMultiplier", 0.25f);
        Resume();
    }

    public void Set050()
    {
        animatorController.SetFloat("speedMultiplier", 0.50f);
        Resume();
    }

    public void Set075()
    {
        animatorController.SetFloat("speedMultiplier", 0.75f);
        Resume();
    }

    public void Set100()
    {
        animatorController.SetFloat("speedMultiplier", 1.00f);
        Resume();
    }

    //-------------------------------------------------------------


    // lead hand button functions
    //-------------------------------------------------------------

    public void SetLeft()
    {
        animatorController.SetBool("mirrored", false);
        animatorController.SetFloat("offset", 0.00f);
        Resume();
    }

    public void SetRight()
    {
        animatorController.SetBool("mirrored", true);
        animatorController.SetFloat("offset", 0.50f);
        Resume();
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


    // Info functions
    //-------------------------------------------------------------

    public void InfoOpen()
    {
        InfoPanel.SetActive(true);
        ToolsPanel.SetActive(false);
    }

    public void InfoClose()
    {
        InfoPanel.SetActive(false);
        ToolsPanel.SetActive(true);
    }

    //-------------------------------------------------------------

}
