using UnityEngine;

public class Ball : MonoBehaviour
{
    public enum BallType
    {
        Heavy,
        Normal,
        Light
    }

    public BallType ballType;

    public float heavyMass = 2f; // Adjust the masses as needed
    public float normalMass = 1f;
    public float lightMass = 0.5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        switch (ballType)
        {
            case BallType.Heavy:
                rb.mass = heavyMass;
                break;
            case BallType.Normal:
                rb.mass = normalMass;
                break;
            case BallType.Light:
                rb.mass = lightMass;
                break;
        }
    }
}
