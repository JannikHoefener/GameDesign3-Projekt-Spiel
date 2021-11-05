using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = playerPos;
    }
}
