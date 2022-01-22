using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRotation : MonoBehaviour
{
    public int rotationStep = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (0,rotationStep * Time.deltaTime,0);
    }
}
