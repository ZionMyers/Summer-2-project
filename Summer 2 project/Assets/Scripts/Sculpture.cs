using UnityEngine;
public class Spin : MonoBehaviour
{
    public float speed = 50f; // Adjust the rotation speed as needed
    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}