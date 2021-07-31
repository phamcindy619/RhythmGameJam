using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Rating : MonoBehaviour
{
    //Getting the total score(with the combo affecting included), the score of the player, and the Sprites of the Grades
    public GameObject ActiveUI;
    public Image rateImage;
    public Image ghostImage;
    public Image foodImage;
    public GameObject RateMenu;
    public Animator animator;
    public int totalScore;
    public int Score;
    private Sprite S, A, B, C, D, F;
    private Sprite ghostWin, ghostLose;

    private void Start()
    {
        S = Resources.Load<Sprite>("Sprites/S");
        A = Resources.Load<Sprite>("Sprites/A");
        B = Resources.Load<Sprite>("Sprites/B");
        C = Resources.Load<Sprite>("Sprites/C");
        D = Resources.Load<Sprite>("Sprites/D");
        F = Resources.Load<Sprite>("Sprites/F");

        ghostWin = Resources.Load<Sprite>("Sprites/ghostWin");
        ghostLose = Resources.Load<Sprite>("Sprites/ghostLose");
    }

    public void Update()
    {
        totalScore = GameManager.instance.totalscore;
        Score = GameManager.instance.currentScore;
        if (SongManager.instance.musicSource.clip.length <= SongManager.instance.songPositionInSec)
        {
            foodImage.sprite = Resources.Load<Sprite>("Sprites/" + SongManager.instance.songName);
            RateScore(totalScore, Score);
            ActiveUI.SetActive(false);
            RateMenu.SetActive(true);
            animator.enabled = false;
        }
    }
    void RateScore(int score,int totalScore)
    {
        Debug.Log("score: " + score);
        Debug.Log("total score: " + totalScore);
        if (score / totalScore >= .95) {
            rateImage.sprite = S;
            ghostImage.sprite = ghostWin;
        }
        else if (score / totalScore >= .9) {
            rateImage.sprite = A;
            ghostImage.sprite = ghostWin;
        }
        else if (score / totalScore >= .8) {
            rateImage.sprite = B;
            ghostImage.sprite = ghostWin;
        }
        else if (score / totalScore >= .7) {
            rateImage.sprite = C;
            ghostImage.sprite = ghostWin;
        }
        else if (score / totalScore >= .6) {
            rateImage.sprite = D;
            ghostImage.sprite = ghostLose;
        }
        else {
            rateImage.sprite = F;
            ghostImage.sprite = ghostLose;
        }
    }
}
