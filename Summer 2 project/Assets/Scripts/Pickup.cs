using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

     public float rotateSpeed =5f; // A var to augment the rotation speeed of this pickup

    public int pointValue = 1;

     private void OnTriggerEnter(Collider other) // onTriggerEnter() is called every time a collider marked as a trigger collider
    // Start is called before the first frame update
    {
        if (other.gameObject.CompareTag("Player")) // if the collider this pickup just hit is tagged as the player
        {
            Destroy(this.gameObject); // Destroy this pickup

            GameManager.Instance.totalPickups -= 1;
            GameManager.Instance.UpdateScore(pointValue);
            AudioManager.Instance.PlaySound("PickUp");
            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * rotateSpeed * Time.deltaTime);
    }
}