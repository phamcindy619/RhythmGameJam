using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject CountdownObject;
    public Text countdownDisplay;
    public int countdowntime;
    public float timepassedinpause;
    [SerializeField]
    GameObject PMenu;
    [SerializeField]
    bool paused = false;

    private void Start()
    {
        CountdownObject.SetActive(false);
    }


    IEnumerator CountDownStart()
    {
        CountdownObject.SetActive(true);
        while(countdowntime > 0)
        {
            countdownDisplay.text = countdowntime.ToString();
            yield return new WaitForSecondsRealtime(1f);

            countdowntime--;
        }
        countdownDisplay.text = "Go!";
        yield return new WaitForSecondsRealtime(.5f);
        CountdownObject.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.isPlaying = true;
        SongManager.instance.ResumeMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            StopCoroutine("CountDownStart");
            Time.timeScale = 0;
            GameManager.instance.isPlaying = false;
            SongManager.instance.PauseMusic();
            paused = true;
            PMenu.SetActive(true);
            countdowntime = 3;
            
        }

        if (paused)
        {
            timepassedinpause = (float)AudioSettings.dspTime - SongManager.instance.dspSongTime;
        }
    }

    public void Resume()
    {

        PMenu.SetActive(false);
        StartCoroutine("CountDownStart");
        paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
