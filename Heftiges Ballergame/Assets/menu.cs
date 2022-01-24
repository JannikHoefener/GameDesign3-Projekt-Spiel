using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Credits;
    // more info to the version
    public Text VersionText;
    public string VersionHint;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuShow();
        // Store and Log the current game version
        GameStatistics.Instance.GameVersion = Application.version;
        Debug.Log("Game Version: " + Application.version);
        VersionText.text = VersionHint + Application.version;
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ShowCredits()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void MainMenuShow()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
