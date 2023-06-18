using UnityEngine;

public class SphereFloat : MonoBehaviour
{
    public float buoyancy = 1.0f; // Buoyancy force applied to the sphere
    public float liquidDensity = 1.0f; // Density of the liquid

    private Rigidbody rb;
    private float liquidLevel;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        liquidLevel = transform.position.y; // Set the liquid level to the initial position of the sphere
    }

    private void FixedUpdate()
    {
        // Check if the sphere is submerged in the liquid
        if (transform.position.y < liquidLevel)
        {
            // Calculate the buoyancy force based on the submerged volume of the sphere
            float displacement = liquidLevel - transform.position.y;
            float submergedVolume = displacement / transform.localScale.y * Mathf.PI * Mathf.Pow(transform.localScale.x / 2f, 2);
            float buoyancyForce = liquidDensity * Physics.gravity.magnitude * submergedVolume;

            // Apply the buoyancy force to the sphere's rigidbody
            rb.AddForce(Vector3.up * buoyancyForce);
        }
    }
}
