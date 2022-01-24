using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end : MonoBehaviour
{
    public GameObject TimeRanOut;
    public GameObject EnemyEnd;
    public GameObject WinEnd;
    public Text ScoreText;
    public Text ScoreDetail;

    // Start is called before the first frame update
    void Start()
    {
        // Calculate Score
        var score = GameStatistics.Instance.Score;

        score += (int)(GameStatistics.Instance.TimeRemaining) * 1;      // Each Second left    +  1 Points
        score += GameStatistics.Instance.Pakete * 500;                  // Each saved Paket    +500 Points
        if (GameStatistics.Instance.inHand) { score += 100; };          // Each Paket in Hand  +100 Points

        DisplayScore(score);
        DisplayDetail(((int)(GameStatistics.Instance.TimeRemaining) * 1), (GameStatistics.Instance.Pakete * 500));

        // Decide which screen has to be shown
        var end = GameStatistics.Instance.EndReason;
        switch (end)
        {
            case 0:
                WinEndShow();       // Player has won
                Debug.Log("Endscreen: Choosed Winning Screen.");
                break;
            case 1:
                TimeRanOutShow();   // Player ran out of time
                Debug.Log("Endscreen: Choosed Time Ran Out Screen.");
                break;
            case 3:
                PlayerGaveUpShow();
                Debug.Log("Endscreen: Choosed Player Gave Up Screen.");
                break;
            default:
                EnemyEndShow();     // Player was spotted
                Debug.Log("Endscreen: Choosed Enemy Screen.");
                break;
        }

        // Last Step: Clean Up Variables!
        CleanUp();
    }

    public void TimeRanOutShow()
    {
        TimeRanOut.SetActive(true);
        EnemyEnd.SetActive(false);
        WinEnd.SetActive(false);
    }

    public void EnemyEndShow()
    {
        TimeRanOut.SetActive(false);
        EnemyEnd.SetActive(true);
        WinEnd.SetActive(false);
    }

    public void WinEndShow()
    {
        TimeRanOut.SetActive(false);
        EnemyEnd.SetActive(false);
        WinEnd.SetActive(true);
    }

    public void PlayerGaveUpShow()
    {
        TimeRanOut.SetActive(false);
        EnemyEnd.SetActive(false);
        WinEnd.SetActive(false);
        //TODO edit this function to add an Score Screen for players who gave up
        Debug.Log("Forwarding to Main Menu");
        MainMenuShow();
    }

    public void MainMenuShow()
    {
        Debug.Log("Called Main Menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); //TODO make async for loading screen
    }

    public void DisplayScore(int score)
    {
        Debug.Log("Score " + score);
        ScoreText.text = "Score " + score.ToString();
    }

    public void DisplayDetail(int pointsTime, int pointsPackets)
    {
        ScoreDetail.text = string.Format("Points for Time Left: {0:0000} \nPoints for Packets collected: {1:0000} \n", pointsTime, pointsPackets);
    }

    public void CleanUp()
    {
        GameStatistics.Instance.TimeRemaining = 10.0f;
        GameStatistics.Instance.Score = 0;
        GameStatistics.Instance.Pakete = 0;
        GameStatistics.Instance.Goal = 10;
        GameStatistics.Instance.inHand = false;
        GameStatistics.Instance.EndReason = 0;
    }
}
