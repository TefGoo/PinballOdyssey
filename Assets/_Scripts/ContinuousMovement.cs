using UnityEngine;

public class ContinuousMovement : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float resetThreshold = -1f;
    private Vector3 startPosition;

    private void Start()
    {
        // Store the initial position of the object
        startPosition = transform.position;
    }

    private void Update()
    {
        // Move the object to the left
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

        // Check if the object has reached the reset threshold
        if (transform.position.x <= resetThreshold)
        {
            // Reset the object's position to the starting position
            transform.position = startPosition;
        }
    }
}
