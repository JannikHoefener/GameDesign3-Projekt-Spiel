using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public GameObject TimeRanOut;
    public GameObject Spotted;
    public GameObject Winning;
    public GameObject IgnoredRules;
    public GameObject PlayerGaveUp;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreDetail;


    // Start is called before the first frame update
    void Start()
    {
        var score = GameStatistics.Instance.Score;

        score += (int)(GameStatistics.Instance.TimeRemaining) * 1;
        score += GameStatistics.Instance.Pakete * 500;
        if (GameStatistics.Instance.inHand) { score += 100; };

        DisplayScore(score);
        // DisplayDetails();

        var reason = GameStatistics.Instance.EndReason;
        switch (reason)
        {
            case 0:
                Debug.Log("Endscreen: Choosed Winning Screen.");
                WinningShow();
                break;
            case 1:
                Debug.Log("Endscreen: Choosed Time Ran Out Screen.");
                TimeRanOutShow();
                break;
            case 2:
                Debug.Log("Endscreen: Choosed Spotted Player Screen.");
                SpottedShow();
                break;
            case 3:
                Debug.Log("Endscreen: Choosed Player Gave Up Screen.");
                PlayerGaveUpShow();
                break;
            case 4:
                Debug.Log("Endscreen: Choosed Player Ignored Rules Screen.");
                IgnoredRulesShow();
                break;
            default:
                Debug.Log($"Endscreen: Unknown Error Occured: reason = {reason}");
                MainMenuShow();
                break;
        }

        CleanUp();
    }

    // Update is called once per frame

    public void DisplayScore(int score)
    {
        Debug.Log($"Score: {score}");
        ScoreText.text = "Score " + score.ToString();
    }

    private void WinningShow()
    {
        TimeRanOut.SetActive(false);
        Spotted.SetActive(false);
        Winning.SetActive(true);
        IgnoredRules.SetActive(false);
        PlayerGaveUp.SetActive(false);
    }

    private void TimeRanOutShow()
    {
        TimeRanOut.SetActive(true);
        Spotted.SetActive(false);
        Winning.SetActive(false);
        IgnoredRules.SetActive(false);
        PlayerGaveUp.SetActive(false);
    }

    private void SpottedShow()
    {
        TimeRanOut.SetActive(false);
        Spotted.SetActive(true);
        Winning.SetActive(false);
        IgnoredRules.SetActive(false);
        PlayerGaveUp.SetActive(false);
    }

    private void PlayerGaveUpShow()
    {
        TimeRanOut.SetActive(false);
        Spotted.SetActive(false);
        Winning.SetActive(false);
        IgnoredRules.SetActive(false);
        PlayerGaveUp.SetActive(true);
    }

    private void IgnoredRulesShow()
    {
        TimeRanOut.SetActive(false);
        Spotted.SetActive(false);
        Winning.SetActive(false);
        IgnoredRules.SetActive(true);
        PlayerGaveUp.SetActive(false);
    }

    public void MainMenuShow()
    {
        Debug.Log("Endscreen: Calling Main Manu.");
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void CleanUp()
    {
        GameStatistics.Instance.TimeRemaining = 10.0f;
        GameStatistics.Instance.Score = 0;
        GameStatistics.Instance.Pakete = 0;
        GameStatistics.Instance.Goal = 10;
        GameStatistics.Instance.inHand = false;
        GameStatistics.Instance.EndReason = 0;
    }
}
