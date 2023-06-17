using UnityEngine;

public class DelayedAudioStart : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayDuration = 5f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - startTime >= delayDuration && !audioSource.isPlaying)
        {
            audioSource.Play();
            enabled = false; // Disable the script after the audio starts playing
        }
    }
}
