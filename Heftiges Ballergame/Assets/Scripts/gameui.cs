using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameui : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;
    public Text TimeText;
    public int timelimit = 300;

    // Start is called before the first frame update
    void Start()
    {
        // call setScore to set the displayed score to 0
        setScore(0); 
        setTime(timelimit);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void setTime(int count)
    {
        TimeText.text = "Time Left: " + count + "s";
    }
}
