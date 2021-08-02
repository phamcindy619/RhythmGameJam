using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject settingsMenu;
    public AudioClip confirmation;

    public void Start()
    {
        confirmation = Resources.Load<AudioClip>("Audio/Menu_Confirm");
    }

    public void Play() {
        Debug.Log("<color=yellow>Play</color>");
        SceneManager.LoadScene("SongSelection");
        SongManager.instance.PlaySingle(confirmation);
    }

    public void Settings()
    {
        Debug.Log("Settings");
        settingsMenu.SetActive(true);
        SongManager.instance.PlaySingle(confirmation);

    }

    public void Back()
    {
        settingsMenu.SetActive(false);
        Debug.Log("Menu");
        SongManager.instance.PlaySingle(confirmation);

    }

    public void Quit()
    {
        Debug.Log("<color=yellow>Quit</color>");
        SongManager.instance.PlaySingle(confirmation);
        Application.Quit();
    }

}
