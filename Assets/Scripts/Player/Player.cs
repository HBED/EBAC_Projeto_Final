using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerSM playerSM;
    public Animator animator;

    public CharacterController characterController;
    public float speed = 2f;
    public float turnSpeed = 2f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    public float speedRun = 1.5f;

    private float vSpeed = 0f;
    public KeyCode jumpKeyCode = KeyCode.Space;
    public KeyCode runKeyCode = KeyCode.R;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(jumpKeyCode))
            {
                vSpeed = jumpSpeed;
            }
        }

        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;

        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        {
            if (Input.GetKey(runKeyCode))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", inputAxisVertical != 0);

        if (Input.GetKey(KeyCode.C))
        {
            playerSM.stateMachine.SwitchState(PlayerSM.GameStates.IDLE);
        }

        if (Input.GetKey(KeyCode.V))
        {
            playerSM.stateMachine.SwitchState(PlayerSM.GameStates.JUMP);
        }

        if (Input.GetKey(KeyCode.B))
        {
            playerSM.stateMachine.SwitchState(PlayerSM.GameStates.RUN);
        }


    }






}

/*
 *      


 * 
 */