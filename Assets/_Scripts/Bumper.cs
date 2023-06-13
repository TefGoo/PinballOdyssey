using UnityEngine;

public class Bumper : MonoBehaviour
{
    public enum BumperType
    {
        Normal,
        Weak,
        Strong
    }

    public BumperType bumperType;

    public float normalForce = 10f; // Adjust the forces as needed
    public float weakForce = 5f;
    public float strongForce = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            switch (bumperType)
            {
                case BumperType.Normal:
                    ballRigidbody.AddForce(transform.up * normalForce, ForceMode.Impulse);
                    break;
                case BumperType.Weak:
                    ballRigidbody.AddForce(transform.up * weakForce, ForceMode.Impulse);
                    break;
                case BumperType.Strong:
                    ballRigidbody.AddForce(transform.up * strongForce, ForceMode.Impulse);
                    break;
            }
        }
    }
}
