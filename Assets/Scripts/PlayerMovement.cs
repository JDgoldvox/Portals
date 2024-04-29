using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    bool stopPos = false;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        //when player presses escape, stop movement
        if (Input.GetKeyDown(KeyCode.Escape) && !stopPos)
        {
            stopPos = true;
        }
        else //when player presses escape, start movement
        {
            stopPos = false;
        }

        if (!stopPos)
        {
            MovePlayer();
        }
        
    }

    private void MyInput()
    {
        //gather Axis
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calc move dir
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //add force to movement dir
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }
}
