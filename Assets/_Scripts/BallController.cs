using UnityEngine;

public class BallController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Horizontal Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0f, 0f) * moveSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, 0f);

        // Jumping
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the ball collides with the ground or any other object you want to bounce off
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("BounceObject"))
        {
            canJump = true;
        }
    }
}
