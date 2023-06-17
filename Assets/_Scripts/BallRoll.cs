using UnityEngine;

public class BallRoll : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the move speed as per your requirements

    private void Update()
    {

        // Move the ball forward in the world space (Z-axis)
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
    }
}
