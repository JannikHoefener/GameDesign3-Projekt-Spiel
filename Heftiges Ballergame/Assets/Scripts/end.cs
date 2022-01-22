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

    // Start is called before the first frame update
    void Start()
    {
        // Calculate Score
        var score = GameStatistics.Instance.Score;

        score += (int)(GameStatistics.Instance.TimeRemaining) * 1;      // Each Second left    +  1 Points
        score += GameStatistics.Instance.Pakete * 500;                  // Each saved Paket    +500 Points
        if (GameStatistics.Instance.inHand) { score += 100; };           // Each Paket in Hand  +100 Points

        DisplayScore(score);

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
            default:
                EnemyEndShow();     // Player was spotted
                Debug.Log("Endscreen: Choosed Enemy Screen.");
                break;
        }
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

    public void MainMenuShow()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void DisplayScore(int score)
    {
        Debug.Log("Score " + score);
        ScoreText.text = score.ToString();
    }
}
