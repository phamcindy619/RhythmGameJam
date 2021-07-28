using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;

    [SerializeField]
    private bool remapping;

    public void Play() {
        Debug.Log("<color=yellow>Play</color>");
        SceneManager.LoadScene("SongSelection");
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
        Debug.Log("<color=yellow>Credits</color>");
        //SceneManager.LoadScene(credits);
    }

    public void Settings()
    {
        Debug.Log("Settings");
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        Debug.Log("Menu");
    }

    public void Quit()
    {
        Debug.Log("<color=yellow>Quit</color>");
        Application.Quit();
    }

}
