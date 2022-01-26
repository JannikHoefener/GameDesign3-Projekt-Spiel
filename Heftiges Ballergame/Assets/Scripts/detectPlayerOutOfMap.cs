using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectPlayerOutOfMap : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player ignores the rules and left the stage");
            GameStatistics.Instance.EndReason = 4;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
        }
    }
}
