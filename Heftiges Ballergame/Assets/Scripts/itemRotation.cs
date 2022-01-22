using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRotation : MonoBehaviour
{
    public int rotationStep = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotates x degrees per second around y axis
        transform.Rotate (0,rotationStep * Time.deltaTime,0);
    }
}
