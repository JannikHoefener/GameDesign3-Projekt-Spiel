using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_playerController : MonoBehaviour
{
    public GameObject rigidBodyObject;
    private Rigidbody playerRb;
    public Actions actions;


    private Vector3 targetDirection;
    public int moveSpeed;
    private float axisInputX;
    private float axisInputZ;
    public int jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = rigidBodyObject.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            playerMovement();
            
        }
    }

    private void playerMovement()
    {
        xy_movement();
        jump();


    }

    private void xy_movement()
    {
        targetDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        transform.Translate(targetDirection * moveSpeed * Time.deltaTime);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            actions.Jump();
        }
    }
}
