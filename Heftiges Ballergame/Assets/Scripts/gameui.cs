using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameui : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;
    public Text TimeText;
    public float timeRemaining = 10;
    public Text HandsText;
    
    public bool timerIsRunning = true;
    //public int currentTime = 0; // contains current time left

    // Start is called before the first frame update
    void Start()
    {
        // call setScore to set the displayed score to 0
        setScore(0); 
        timerIsRunning = true;
        updateHands();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            GameStatistics.Instance.TimeRemaining = timeRemaining;

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                setTime(timeRemaining);
            }
            else 
            {
                Debug.Log("Time ran out.");
                GameStatistics.Instance.EndReason = 1;          // Tell the end screen the reason
                GameStatistics.Instance.TimeRemaining = 0;
                timerIsRunning = false;
                UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
            }
        } 
    }

    void setScore(int points)
    {
        // Set given points in score
        score = points;
        ScoreText.text = score.ToString();
    }

    // Update Score
    void addScore(int points)
    {
        // Add given points to current score and update the text
        score += points;
        ScoreText.text = score.ToString();
    }

    void setTime(float displayTime)
    {
        displayTime += 1;
        // calculate minutes and seconds to show in UI
        float minutes = Mathf.FloorToInt(displayTime / 60);
        float seconds = Mathf.FloorToInt(displayTime % 60);
        // use string format for fancy output
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void updateHands()
    {
        if (GameStatistics.Instance.inHand)
        {
            HandsText.text = "Hands full";
        }
        else 
        {
            HandsText.text = "Hands empty";
        }
    }
}
