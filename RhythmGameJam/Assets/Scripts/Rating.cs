using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rating : MonoBehaviour
{
    //Getting the total score(with the combo affecting included), the score of the player, and the Sprites of the Grades
    public GameObject ActiveUI;
    public Image rateImage;
    public GameObject RateMenu;
    public int totalScore;
    public int Score;
    public Sprite S, A, B, C, D, F;

    private void Start()
    {
        S = Resources.Load<Sprite>("Sprites/S");
        A = Resources.Load<Sprite>("Sprites/A");
        B = Resources.Load<Sprite>("Sprites/B");
        C = Resources.Load<Sprite>("Sprites/C");
        D = Resources.Load<Sprite>("Sprites/D");
        F = Resources.Load<Sprite>("Sprites/F");
    }

    public void Update()
    {
        totalScore = GameManager.instance.totalscore;
        Score = GameManager.instance.currentScore;
        if (SongManager.instance.musicSource.clip.length <= SongManager.instance.songPositionInSec)
        {
            RateScore(totalScore,Score);
            ActiveUI.SetActive(false);
            RateMenu.SetActive(true);
        }
        else
        {
        }
    }
    void RateScore(int score,int totalScore)
    {
        //Get the sixth of the totalscore
        int sixth = totalScore / 6;

        if (score > sixth * 6) {
            rateImage.sprite = S;
            Debug.Log("S score!");
        }
        else if (score > sixth * 5) {
            rateImage.sprite = A;
            Debug.Log("A score!");
        }
        else if (score > sixth * 4) {
            rateImage.sprite = B;
            Debug.Log("B score!");
        }
        else if (score > sixth * 3) {
            rateImage.sprite = C;
            Debug.Log("C score!");
        }
        else if (score > sixth * 2) {
            rateImage.sprite = D;
            Debug.Log("D score!");
        }
        else {
            rateImage.sprite = F;
            Debug.Log("F score!");
        }
    }
}
