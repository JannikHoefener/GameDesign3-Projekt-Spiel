using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerControllerNew : MonoBehaviour
{
    
    //Character Object references
    private Rigidbody playerRb;
    public GameObject character;
    public Actions animations;
    public Animator animator;

    //GameStatistic reference
    public GameStatistics gameStatistics;

    //GameStatistic reference
    public GameStatistics gameStatistics;

    //Movement variables
    private PlayerInput playerInput;
    private InputAction movement;
    private InputAction jumpAction;
    private InputAction escape;

    //Movement directions
    private Vector2 moveDirection;
    private Vector3 targetDirection;

    //Movement factors
    public int moveSpeed;
    public float rotationSpeed;
    public int jumpForce;
    private int isWalking;

    private bool hitGround; //Limit fuers Jumpen

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRb = GetComponent<Rigidbody>();

        movement = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        escape = playerInput.actions["Escape"];
        hitGround = true;
    }

    private void OnEnable()
    {
        movement.performed += ctx1 => OnMove(ctx1) ;
        movement.canceled += ctx1 => OnStopMove(ctx1);
        movement.Enable();   

        jumpAction.performed += ctx2 => DoJump(ctx2);
        jumpAction.Enable();

        escape.performed += ctx3 => EndGame(ctx3);
        escape.Enable();
    }

    public void EndGame(InputAction.CallbackContext ctx)
    {
        Debug.Log("Player pressed esc/ start; Game is Ending : playerControllerNew EndGame()");
        GameStatistics.Instance.EndReason = 3;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Endscreen");
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveDirection= ctx.ReadValue<Vector2>();
        animations.Walk();
        isWalking = 1;

        Debug.Log(targetDirection);
        Debug.Log("OnMove called");
    }
    private void OnStopMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("OnStopMove called");
        moveDirection = ctx.ReadValue<Vector2>();
        isWalking = 0;
        animations.Stay();
        
        
    }

    public void DoJump(InputAction.CallbackContext ctx)
    {
        if (hitGround == true)
        {
            hitGround = false;
            animations.Jump();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    private void Move(Vector2 moveDirection)
    {
        targetDirection = new Vector3(moveDirection.x, 0, moveDirection.y);
        RotateToDirection(targetDirection);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * isWalking);
        
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
            if (isWalking == 1)
            {
                animations.Walk();
            }
        }
        else
        {
            animations.Stay();
            isWalking = 0;
        }
    }

    private void OnDisable()
    {
        movement.Disable();
        jumpAction.Disable();
        escape.Disable();
    }

    private void Update()
    {
        //String test = controls.Player.Move.ToString();
        //Debug.Log(test);

        Move(moveDirection);   
    }
}
