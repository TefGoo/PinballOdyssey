using UnityEngine;

public class BounceTrigger : MonoBehaviour
{
    public float bounceForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 bounceDirection = (collision.gameObject.transform.position - transform.position).normalized;
            rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
