using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    //Getting the total score(with the combo affecting included), the score of the player, and the Sprites of the Grades
    public int totalScore;
    public int Score;
    public Sprite S, A, B, C, D, F;

    private void Start()
    {
       
    }

    public void Update()
    {
        if (GameManager.instance.isPlaying && SongManager.instance.musicSource.clip.length <= SongManager.instance.songPositionInSec)
        {
            Debug.Log("File ended");

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
            Debug.Log("F score!");
        }else if(score <= sixth * 2)//If the score is a 2/6 of the total score, is a D grade
        {
            Debug.Log("D score!");
        }
        else if (score <= sixth * 3)//If the score is a 3/6 of the total score, is a C grade
        {
            Debug.Log("C score!");
        }
        else if (score <= sixth * 4)//If the score is a 4/6 of the total score, is a B grade
        {
            Debug.Log("B score!");
        }
        else if (score <= sixth * 5)//If the score is a 5/6 of the total score, is a A grade
        {
            Debug.Log("A score!");
        }else if(score <= sixth * 6)//If the score is a 6/6 of the total score, is a S grade
        {
            Debug.Log("S score!");
        }
    }
}
