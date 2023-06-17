using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshPro timerText;
    private float elapsedTime;

    private void Start()
    {
        // Clear the stored elapsed time when SampleScene is loaded
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            PlayerPrefs.DeleteKey("ElapsedTime");
        }

        // Load the previously stored elapsed time
        elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        UpdateTimerText();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000f);

        timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    private void OnDestroy()
    {
        // Store the elapsed time when the scene changes
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
    }
}
