using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.rotation = Quaternion.AngleAxis(90, Vector3.up);

        transform.Rotate(0, 0, 20 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }
}
