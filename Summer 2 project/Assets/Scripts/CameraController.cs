using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
      // The object the camera will follow

   public GameObject target; // Assign in editor

   public Vector3 posOffset; // Assign in editor


    // Start is called before the first frame update
    void Start()
    {
        // 
        transform.position = target.transform.position + posOffset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + posOffset; // move the camera to follow the targetg
     
     
        }
    }
     
}
