using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource song;
    public bool isPlaying;
    public Note note;
    public static GameManager instance;

    // Scoreboard
    public int currCombo;
    public TextMeshProUGUI comboText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        comboText.text = "Combo: 0";
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

        currCombo++;
        comboText.text = "Combo: " + currCombo;
    }

    public void NoteMissed() {
        Debug.Log("note missed");

        currCombo = 0;
        comboText.text = "Combo: 0";
    }
}
