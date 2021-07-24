using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public string play;
    public string credits;
    public string mainmenu;

    public void Play() {
        Debug.Log("<color=yellow>"+play+"</color>");
        //SceneManager.LoadScene(play);
    }

    public void Credit()
    {
        Debug.Log("<color=yellow>" + credits + "</color>");
        //SceneManager.LoadScene(credits);
    }

    public void Quit()
    {
        Debug.Log("<color=yellow>Quited</color>");
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainmenu);
    }
}
