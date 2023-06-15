using UnityEngine;

public class ObjectCollisionHandler : MonoBehaviour
{
    public Material collisionMaterial;
    public AudioClip collisionSoundEffect;
    public float soundEffectVolume = 0.5f; // Adjust the volume level here
    private Material originalMaterial;
    private AudioSource audioSource;
    private bool isBallTouching;

    private void Start()
    {
        // Store the original material of the object
        originalMaterial = GetComponent<Renderer>().material;

        // Add an AudioSource component to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = collisionSoundEffect;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Change the object's material to the collision material
            GetComponent<Renderer>().material = collisionMaterial;
            isBallTouching = true;

            // Play the collision sound effect with adjusted volume
            audioSource.volume = soundEffectVolume;
            audioSource.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Delay the reverting of material to original material
            Invoke("RevertToOriginalMaterial", 0.2f);
            isBallTouching = false;
        }
    }

    private void RevertToOriginalMaterial()
    {
        // Revert the object's material to the original material
        GetComponent<Renderer>().material = originalMaterial;
    }

    private void Update()
    {

    }
}
