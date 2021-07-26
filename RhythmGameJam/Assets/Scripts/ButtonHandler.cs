using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    //publics
    public string play;
    public string credits;
    public string mainmenu;
    public GameObject settings;
    public GameObject MainM;
    public GameObject RemapMessage;
    public TextMeshProUGUI remaptxt;

    //privs
    [SerializeField]
    bool remapping;
    public void Play() {
        Debug.Log("<color=yellow>"+play+"</color>");
        //SceneManager.LoadScene(play);
    }

    public void Update()
    {
        if (Input.anyKeyDown && remapping)
        {
            Debug.Log("You pressed " + Input.inputString);
        }
    }
    public void Credit()
    {
        Debug.Log("<color=yellow>" + credits + "</color>");
        //SceneManager.LoadScene(credits);
    }

    public void Settings()
    {
        MainM.SetActive(false);
        Debug.Log("Settings");
        settings.SetActive(true);

    }

    public void Back()
    {
        settings.SetActive(false);
        Debug.Log("Menu");
        MainM.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("<color=yellow>Quited</color>");
        Application.Quit();
    }

}
