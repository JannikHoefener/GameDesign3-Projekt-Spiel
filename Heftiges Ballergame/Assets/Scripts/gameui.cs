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
    
    public bool timerIsRunning = true;
    //public int currentTime = 0; // contains current time left

    // Start is called before the first frame update
    void Start()
    {
        // call setScore to set the displayed score to 0
        setScore(0); 
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                setTime(timeRemaining);
            }
            else 
            {
                Debug.Log("Time ran out.");
                
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }    
        // Sekunden in der Laufzeit ueber DeltaTime
        //timer += Time.deltaTime;
        //int seconds = (int)(timer % 60);

        // Spielzeit abgelaufen -> Game Over
        //if (seconds == timelimit)
        /*{
            gameRunning = false; // Spiel gestoppt
        }
        while (gameRunning) 
        {
            setTime(timelimit-seconds);
        }*/
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
}
