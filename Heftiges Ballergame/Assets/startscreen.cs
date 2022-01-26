using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class startscreen : MonoBehaviour
{
    public GameObject Credits;
    public TextMeshProUGUI VersionText;

    bool ShowCredits = false;

    // public Text VersionText;
    // public string VersionHint;

    // Start is called before the first frame update
    void Start()
    {
        GameStatistics.Instance.GameVersion = Application.version;
        Debug.Log("Game Version: " + Application.version);
        // VersionText.text = VersionHint + Application.version;
        VersionText.text = Application.version;
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ToggleCredits()
    {
        if (ShowCredits)
        {
            Credits.SetActive(false);
            ShowCredits = false;
            // Debug.Log($"Toggled Credits, new Value {ShowCredits}");
        }
        else
        {
            Credits.SetActive(true);
            ShowCredits = true;
            // Debug.Log($"Toggled Credits, new Value {ShowCredits}");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenItchURL()
    {
        Application.OpenURL("https://soerenh.itch.io/get-out");
    }
}
