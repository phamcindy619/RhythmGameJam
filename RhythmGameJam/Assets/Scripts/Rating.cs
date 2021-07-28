using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rating : MonoBehaviour
{
    public int totalScore;
    public int Score;
    public GameObject S, A, B, C, D, F;

    private void Start()
    {
        RateScore(Score, totalScore);
    }

    void RateScore(int score,int totalScore)
    {
        int sixth = totalScore / 6;
        if(score <= sixth)
        {
            Debug.Log("F score!");
        }else if(score <= sixth * 2)
        {
            Debug.Log("D score!");
        }
        else if (score <= sixth * 3)
        {
            Debug.Log("C score!");
        }
        else if (score <= sixth * 4)
        {
            Debug.Log("B score!");
        }
        else if (score <= sixth * 5)
        {
            Debug.Log("A score!");
        }else if(score <= sixth * 6)
        {
            Debug.Log("S score!");
        }
    }
}
