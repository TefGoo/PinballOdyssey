using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float elapsedTime;
    private float bestTime;

    private void Start()
    {
        // Reset the timer when SampleScene is loaded
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "SampleScene")
        {
            elapsedTime = 0f;
            PlayerPrefs.DeleteKey("ElapsedTime");
        }
        else
        {
            // Load the previously stored elapsed time
            elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        }

        // Load the previously stored best time
        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);

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
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);

        if (elapsedTime < bestTime)
        {
            bestTime = elapsedTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
    }
}
