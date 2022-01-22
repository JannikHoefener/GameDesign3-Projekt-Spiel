using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    public GameObject TimeRanOut;
    public GameObject EnemyEnd;
    public GameObject WinEnd;

    // Start is called before the first frame update
    void Start()
    {
        var a = GameStatistics.Instance.TimeRemaining;
        var b = GameStatistics.Instance.Score;
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

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
