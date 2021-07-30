using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rating : MonoBehaviour
{
    //Getting the total score(with the combo affecting included), the score of the player, and the Sprites of the Grades
    public GameObject ActiveUI;
    public Image rateimage;
    public GameObject RateMenu;
    public int totalScore;
    public int Score;
    public Sprite S, A, B, C, D, F;

    private void Start()
    {
 
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
        //If the score is a 1/6 of the total score, is a F grade
        if(score <= sixth)
        {
            rateimage.sprite = F;
            Debug.Log("F score!");
        }else if(score <= sixth * 2)//If the score is a 2/6 of the total score, is a D grade
        {
            rateimage.sprite = D;
            Debug.Log("D score!");
        }
        else if (score <= sixth * 3)//If the score is a 3/6 of the total score, is a C grade
        {
            rateimage.sprite = C;
            Debug.Log("C score!");
        }
        else if (score <= sixth * 4)//If the score is a 4/6 of the total score, is a B grade
        {
            rateimage.sprite = B;
            Debug.Log("B score!");
        }
        else if (score <= sixth * 5)//If the score is a 5/6 of the total score, is a A grade
        {
            rateimage.sprite = A;
            Debug.Log("A score!");
        }else if(score <= sixth * 6)//If the score is a 6/6 of the total score, is a S grade
        {
            rateimage.sprite = S;
            Debug.Log("S score!");
        }
    }
}
