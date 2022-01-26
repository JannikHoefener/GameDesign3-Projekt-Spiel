using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Guard: Hitbox Collision detected");

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Guard: Spotted Player.");
            GameStatistics.Instance.EndReason = 2;
            UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
        }
    }
}
