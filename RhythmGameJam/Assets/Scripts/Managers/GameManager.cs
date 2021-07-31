using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying;
    public static GameManager instance = null;

    public int beatsShownInAdvance;

    // Scoreboard
    public int currCombo;
    public Text comboText;
    public int comboTracker;
    public int[] comboThresholds;

    public int currentScore;
    public int scorePerNote = 10;
    public Text textScore;
    public Text textHit;
    public Text textMiss;
    //Fake Perfect
    public int totalscore;
    public int fakeCombo;
    public int fakecombotracker;
    //Sections
    public int section = 1;
    public int totalscore1 = 4790;
    int multiply;
    int eigth; 
    // Start is called before the first frame update
    void Start()
    {
        eigth = totalscore1/8;
        fakeCombo = 1;
        currCombo = 1;
        beatsShownInAdvance = 5;
    }

    void Awake() {
        // Check if there is another GameManager
        if (instance == null)
            instance = this;
        // Destroy any duplicate
        else if (instance != this)
            Destroy(gameObject);
        
        // Don't destroy GameManager when reloading the scene
        DontDestroyOnLoad(gameObject);

        textHit.enabled = false;
        textMiss.enabled = false;

        comboText.text = "Combo: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore == eigth * 8)
        {
            section += 1;
        }
        else if (currentScore == eigth * 7)
        {
            section += 1;
        }
        else if (currentScore == eigth * 6)
        {
            section += 1;

        }
        else if (currentScore == eigth * 5)
        {
            section += 1;

        }
        else if (currentScore == eigth * 4)
        {
            section += 1;

        }
        else if(currentScore == eigth * 3)
        {
            section += 1;

        }
        else if(currentScore == eigth * 2)
        {
            section += 1;

        }

        if (!isPlaying) {
            if (Input.anyKeyDown) {
                isPlaying = true;
                SongManager.instance.PlayMusic();
            }
        }
    }

    public void NoteHit() {
        Debug.Log("note hit");


        if(currCombo - 1 < comboThresholds.Length)
        {
            comboTracker++;

            if (comboThresholds[currCombo - 1] <= comboTracker)
            {
                comboTracker = 0;
                currCombo++;

            }
        }

        comboText.text = "Combo: " + currCombo;

        currentScore = currentScore + scorePerNote * currCombo;
        Debug.Log(currentScore);

        textScore.text = "Score: " + currentScore;
        textHit.enabled = true;
        textMiss.enabled = false;
    }

    public void FakePerfect()
    {
        totalscore = totalscore + scorePerNote;
    }

    public void NoteMissed() {
        Debug.Log("note missed");

        textHit.enabled = false;
        textMiss.enabled = true;

        currCombo = 1;
        comboTracker = 0;
        comboText.text = "Combo: " + currCombo;
    }
}
