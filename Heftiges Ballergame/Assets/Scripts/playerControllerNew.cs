using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerNew : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject character;
    public Actions animations;

    //private PlayerControl controls;
    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction jumpAction;

    private Vector2 moveDirection;
    private Vector3 targetDirection;

    public int moveSpeed;
    public float rotationSpeed;
    public int jumpForce;

    private bool hitGround;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();

        movement = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];

        hitGround = true;
    }

    private void OnEnable()
    {

        movement.performed += ctx1 => OnMove(ctx1) ;
        movement.canceled += ctx1 => OnStopMove(ctx1);
        movement.Enable();
        

        jumpAction.performed += ctx2 => DoJump(ctx2);
        jumpAction.Enable();



    }

    

    public void OnMove(InputAction.CallbackContext ctx)
    {

        moveDirection= ctx.ReadValue<Vector2>();
        animations.Walk();
        Debug.Log(targetDirection);
    }
    private void OnStopMove(InputAction.CallbackContext ctx)
    {
        moveDirection = ctx.ReadValue<Vector2>();
        animations.Stay();
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if (hitGround == true)
        {
            hitGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animations.Jump();
        }
    }

    private void Move(Vector2 moveDirection)
    {
        targetDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
        transform.Translate(targetDirection * moveSpeed * Time.deltaTime);

        RotateToDirection(targetDirection);
    }

    private void RotateToDirection(Vector3 targetDirection)
    {
        if (targetDirection.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hitGround = true;
        }
    }

    private void OnDisable()
    {
        movement.Disable();
        jumpAction.Disable();
    }

    private void Update()
    {
        //String test = controls.Player.Move.ToString();
        //Debug.Log(test);

        Move(moveDirection);   
    }
}
