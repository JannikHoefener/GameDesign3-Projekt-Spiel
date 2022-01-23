using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupQuestItem : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameStatistics.Instance.Goal = 4;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pickup Questitem
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            GameStatistics.Instance.inHand = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Dropzone"))
        {
            GameStatistics.Instance.inHand = false;
        }
    }
}
