using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource song;
    public bool isPlaying;
    public NoteScroller note;
    public static GameManager instance;

    // Scoreboard
    public int currCombo;
    public TextMeshProUGUI comboText;

    public int currentScore;
    public int scorePerNote = 10;
    public Text textScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //comboText.text = "Combo: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying) {
            if (Input.anyKeyDown) {
                isPlaying = true;
                note.hasStarted = true;
            }
        }
    }

    public void NoteHit() {
        Debug.Log("note hit");

        //currCombo++;
        //comboText.text = "Combo: " + currCombo;

        currentScore = currentScore + scorePerNote;
        Debug.Log(currentScore);

        textScore.text = "Score: " + currentScore;
    }

    public void NoteMissed() {
        Debug.Log("note missed");

        //currCombo = 0;
        //comboText.text = "Combo: 0";
    }
}
