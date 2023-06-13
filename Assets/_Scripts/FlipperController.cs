using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float maxAngle = 80f; // Maximum rotation angle of the flipper
    public float rotationSpeed = 300f; // Speed at which the flipper rotates
    public float returnSpeed = 150f; // Speed at which the flipper returns to its original position

    private Quaternion restRotation; // The initial rotation of the flipper
    private Quaternion targetRotation; // The target rotation when the button is pressed
    private Quaternion initialRotation; // The initial rotation when the button is pressed

    private new Rigidbody rigidbody;
    private bool isPressed; // Flag indicating if the button is currently pressed
    private Quaternion tableTiltRotation; // The rotation representing the table's tilt

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = Mathf.Infinity;

        // Store the initial rotation of the flipper
        restRotation = transform.localRotation;

        // Calculate the target rotation by combining the flipper's local rotation with the table's tilt
        targetRotation = Quaternion.Euler(0f, maxAngle, 0f) * restRotation;

        // Store the initial rotation when the button is pressed
        initialRotation = restRotation;

        // Calculate the rotation representing the table's tilt
        tableTiltRotation = Quaternion.Euler(0f, 0f, -15f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Button is pressed, rotate to the target rotation
            isPressed = true;
            Quaternion currentRotation = transform.localRotation;

            // Calculate the rotation towards the target rotation using rotationSpeed
            Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);

            // Apply the new rotation to the flipper
            rigidbody.MoveRotation(newRotation);
        }
        else
        {
            // Button is released, return to the rest position
            if (isPressed)
            {
                Quaternion currentRotation = transform.localRotation;

                // Calculate the rotation towards the initial rotation using returnSpeed
                Quaternion newRotation = Quaternion.RotateTowards(currentRotation, initialRotation, returnSpeed * Time.fixedDeltaTime);

                // Apply the new rotation to the flipper
                rigidbody.MoveRotation(newRotation);

                // Check if the flipper has returned to its initial rotation
                if (Quaternion.Angle(newRotation, initialRotation) < 0.1f)
                {
                    isPressed = false; // Reset the flag indicating the button is no longer pressed
                }
            }
        }
    }
}
