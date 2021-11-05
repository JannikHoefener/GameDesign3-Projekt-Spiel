using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_PowerUp_Behaviour : MonoBehaviour
{

    private Rigidbody rb;
    private bool hasPowerUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }
}
