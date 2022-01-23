using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public int goal = 4;

    // Start is called before the first frame update
    void Start()
    {
        GameStatistics.Instance.Goal = goal;
        GameStatistics.Instance.inHand = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for GameEnd Condition - all packets collected
        if (GameStatistics.Instance.Pakete == GameStatistics.Instance.Goal)
        {
            Debug.Log("Quest: Winning Condition fulfilled.");
            GameStatistics.Instance.EndReason = 0;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
        }
    }

    // Pickup Questitem
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            if (!GameStatistics.Instance.inHand) // when Hands empty do:
            {
                Debug.Log("Quest: Picked GPU.");
                GameStatistics.Instance.inHand = true;
                Destroy(other.gameObject);
            }
            else { Debug.Log("Quest: Hands full. Did not pick."); }
        }
        else if (other.gameObject.CompareTag("Dropzone"))
        {
            if (GameStatistics.Instance.inHand) // when Hands full do:
            {
                Debug.Log("Quest: Dropped GPU.");
                GameStatistics.Instance.inHand = false;
                GameStatistics.Instance.Pakete += 1;
            }
            else { Debug.Log("Quest: You have nothing in Hands to drop here."); }
        }
    }
}
