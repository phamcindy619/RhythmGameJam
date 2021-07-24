using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject CountdownObject;
    public TextMeshProUGUI countdownDisplay;
    public int countdowntime;
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
        countdownDisplay.text = "Cook!";
        yield return new WaitForSecondsRealtime(.5f);
        CountdownObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            paused = true;
            PMenu.SetActive(true);
            Time.timeScale = 0;
        }else if(Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            paused = false;
            PMenu.SetActive(false);
            StartCoroutine(CountDownStart());
        }
    }

    private void FixedUpdate()
    {
        
    }
}
