using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float flipperForce = 500f;
    public float maxRotationAngle = 45f;
    public float returnSpeed = 10f; // Adjust the return speed of the flippers
    public string inputButton = "Fire1"; // Change this to the desired input button

    private Quaternion initialRotation;
    private bool isFlipperActivated;

    private void Start()
    {
        // Store the initial rotation of the flipper
        initialRotation = transform.rotation;

        // Set the rigidbody's gravity to zero
        GetComponent<Rigidbody>().useGravity = false;
    }

    private void Update()
    {
        // Check for input to activate the flipper
        if (Input.GetButtonDown(inputButton))
        {
            // Set the flipper activation flag to true
            isFlipperActivated = true;
        }

        // Check for input release to deactivate the flipper
        if (Input.GetButtonUp(inputButton))
        {
            // Set the flipper activation flag to false
            isFlipperActivated = false;
        }

        // Rotate the flipper while it is activated
        if (isFlipperActivated)
        {
            // Apply a torque force to the flipper to rotate it
            GetComponent<Rigidbody>().AddTorque(transform.up * flipperForce);
        }
        else
        {
            // Return the flipper to its original rotation
            ReturnToOriginalRotation();
        }

        // Limit the rotation angle of the flipper
        ClampRotation();
    }

    private void ClampRotation()
    {
        // Calculate the current angle of rotation
        float currentAngle = Quaternion.Angle(initialRotation, transform.rotation);

        // Clamp the rotation within the specified range
        if (currentAngle > maxRotationAngle)
        {
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, initialRotation, currentAngle - maxRotationAngle);
            GetComponent<Rigidbody>().MoveRotation(newRotation);
        }
    }

    private void ReturnToOriginalRotation()
    {
        // Smoothly rotate the flipper back to its original rotation
        Quaternion targetRotation = initialRotation;
        Quaternion currentRotation = transform.rotation;
        Quaternion newRotation = Quaternion.Slerp(currentRotation, targetRotation, returnSpeed * Time.deltaTime);
        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }
}
