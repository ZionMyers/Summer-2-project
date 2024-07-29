using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
// How to make a C# ----> Accesor datatype varName


public CharacterController controller; // A var to hold the players char controller component


public float moveSpeed = 5;


private Vector3 moveDirections = Vector3.zero;


public int health;


private EnemyFollow enemy;


public float rotateSpeed = 5f; // speed the player rotate


public Animator animController; // A var to hold the players anime controller component

[Header("Movement")]

public float groundDrag;

// public float jumpForce;
// public float jumpCooldown;
// public float airMultiplier;
// bool readyToJump;

// [Header("Keybinds")]
// public KeyCode jumpKey = KeyCode.Space;

 [Header("Ground check")]
 public float playerHeight;
 public LayerMask WhatIsGround;
 bool grounded;

 public Transform orientation;

 float horizontalInput;
 float verticalInput;

 Vector3 moveDirection;

 Rigidbody rb;


// Start is called before the first frame update
private void Start()
{
controller = GetComponent<CharacterController>();

enemy = FindObjectOfType<EnemyFollow>();

animController = GetComponent<Animator>();

 rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
}


// Update is called once per frame
void Update()
{
// gather input from the player
float horizontalInput = Input.GetAxis("Horizontal");
float verticalInput = Input.GetAxis("Vertical");

// if(Input.GetKey(jumpKey) && readyToJump && grounded)
// {
  //  readyToJump = false;

   // jump();

   // Invoke(nameof(ResetJump), jumpCooldown);
// }

// calculate direction the player should based on our collected input
Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);


// move the player based on input
controller.Move(movement * moveSpeed * Time.deltaTime);


// vector.3 = (0, 0, 0) --> Player is not moving
if (movement != Vector3.zero) // if the player is moving...
{
 animController.SetBool("IsMoving" , true); // controller to transition to run   

//rotate the player in direction they are moving over time
Quaternion targetRotation = Quaternion.LookRotation(movement); // storing the rotation needed


// rotate the player based on its current Rotation values and the target rotation value
transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
}
else // the player is no longer moving
{
    animController.SetBool("IsMoving" , false);
}
}

  private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

         if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
 
       //  else if(!grounded)
       //   rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

 private void FixedUpdate()
    {
        MovePlayer();
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

  // private void jump()
  // {
  //  rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

  //  rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
  // }

 // private void ResetJump()
  //{
   // readyToJump = true;
  //}




void OnTriggerEnter(Collider other)
{
if(other.CompareTag("Enemy"))
{
// trigger the damage
health = health - enemy.damage;


if(health <=0)
{
GameManager.Instance.GameOver();


Destroy(gameObject);
}
}
}
}
