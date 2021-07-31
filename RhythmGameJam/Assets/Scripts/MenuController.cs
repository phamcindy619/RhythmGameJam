using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public AudioSource buttonaudiosource;
    public AudioClip confirmation;

    [SerializeField]
    private bool remapping;

    public void Start()
    {
    }

    public void Play() {
        Debug.Log("<color=yellow>Play</color>");
        SceneManager.LoadScene("SongSelection");
        buttonaudiosource.PlayOneShot(confirmation);
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
        buttonaudiosource.PlayOneShot(confirmation);

    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        Debug.Log("Menu");
        buttonaudiosource.PlayOneShot(confirmation);

    }

    public void Quit()
    {
        Debug.Log("<color=yellow>Quit</color>");
        buttonaudiosource.PlayOneShot(confirmation);

        Application.Quit();
    }

}
