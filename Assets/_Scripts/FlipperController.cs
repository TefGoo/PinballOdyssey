using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public float flipperForce = 2000f;
    public float flipperRestRotation = 0f;
    public float flipperPressedRotation = 45f;
    public float flipperReturnSpeed = 100f;
    public KeyCode flipperKey;

    private HingeJoint hingeJoint;
    private JointMotor motor;
    private bool isReturning = false;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        hingeJoint.useMotor = true;

        motor = hingeJoint.motor;
        motor.force = flipperForce;
        hingeJoint.motor = motor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(flipperKey))
        {
            motor.targetVelocity = flipperForce;
            hingeJoint.motor = motor;
            isReturning = false;
        }

        if (Input.GetKeyUp(flipperKey))
        {
            isReturning = true;
        }

        if (isReturning)
        {
            motor.targetVelocity = -flipperReturnSpeed;
            hingeJoint.motor = motor;

            if (Mathf.Abs(hingeJoint.angle - flipperRestRotation) < 1f)
            {
                motor.targetVelocity = 0f;
                hingeJoint.motor = motor;
                isReturning = false;
            }
        }
    }
}
