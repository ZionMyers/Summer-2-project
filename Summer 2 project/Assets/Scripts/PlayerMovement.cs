using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 [Header("Movement")]
 public float moveSpeed;

public float groundDrag;

 [Header("Ground check")]
 public float playerHeight;
 public LayerMask WhatIsGround;
 bool grounded;

 public Transform orientation;

 float horizontalInput;
 float verticalInput;

 Vector3 moveDirection;

 Rigidbody rb;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, WhatIsGround);

        MyInput();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    
    // Update is called once per frame
  private  void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
    
    private void SpeedContol()
   {
      Vector3 flatVe1 = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

      if(flatVe1.magnitude > moveSpeed)
      {
        Vector3 limitedVel = flatVe1.normalized * moveSpeed;
        rb.velocity = new Vector3(limitedVel.x,rb.velocity.y, limitedVel.z);
        
      }
   }
}


