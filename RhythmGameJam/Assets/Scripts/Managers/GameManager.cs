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

    // Start is called before the first frame update
    void Start()
    {
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
        if (!isPlaying) {
            isPlaying = true;
            SongManager.instance.PlayMusic();
        }
    }

    public void NoteHit() {
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

        currentScore += scorePerNote * currCombo;

        textScore.text = "Score: " + currentScore;
        textHit.enabled = true;
        textMiss.enabled = false;
    }

    public void FakePerfect()
    {
        totalscore += scorePerNote;
    }

    public void NoteMissed() {
        textHit.enabled = false;
        textMiss.enabled = true;

        currCombo = 1;
        comboTracker = 0;
        comboText.text = "Combo: " + currCombo;
    }
}
