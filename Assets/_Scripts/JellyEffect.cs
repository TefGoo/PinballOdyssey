using UnityEngine;

public class JellyEffect : MonoBehaviour
{
    public float jellyScaleFactor = 1.2f; // Adjust the scale factor for the jelly effect
    public float jellyDuration = 0.2f; // Adjust the duration of the jelly effect
    public AudioClip collisionSoundEffect;
    public float soundEffectVolume = 0.5f; // Adjust the volume level of the sound effect
    private Vector3 originalScale;
    private AudioSource audioSource;
    private bool isBallTouching;

    private void Start()
    {
        // Store the original scale of the object
        originalScale = transform.localScale;

        // Add an AudioSource component to the object
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = collisionSoundEffect;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBallTouching = true;

            // Start the jelly effect coroutine
            StartCoroutine(StartJellyEffect());

            // Play the collision sound effect
            audioSource.volume = soundEffectVolume;
            audioSource.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isBallTouching = false;
        }
    }

    private System.Collections.IEnumerator StartJellyEffect()
    {
        // Scale up the object
        Vector3 targetScale = originalScale * jellyScaleFactor;
        float elapsedTime = 0f;
        while (elapsedTime < jellyDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / jellyDuration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            yield return null;
        }

        // Scale down the object
        elapsedTime = 0f;
        while (elapsedTime < jellyDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / jellyDuration;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
            yield return null;
        }

        // Set the scale back to the original scale
        transform.localScale = originalScale;
    }

    private void Update()
    {

    }
}
