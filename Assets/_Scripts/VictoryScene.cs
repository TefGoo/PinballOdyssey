using UnityEngine;
using TMPro;

public class VictoryScene : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bestTimeText;
    public float delayBetweenCharacters = 0.05f;
    private string resultText;
    private int currentCharIndex;
    private float lastCharTime;
    private float bestTime;

    private void Start()
    {
        // Retrieve the elapsed time from PlayerPrefs
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        UpdateTimeText(elapsedTime);

        // Retrieve the best time from PlayerPrefs
        bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
        UpdateBestTimeText();

        // Initialize the typewriter effect variables
        resultText = timeText.text;
        timeText.text = "";
        currentCharIndex = 0;
        lastCharTime = Time.time;
    }

    private void Update()
    {
        // Check if enough time has passed to display the next character
        if (currentCharIndex < resultText.Length && Time.time - lastCharTime > delayBetweenCharacters)
        {
            timeText.text += resultText[currentCharIndex]; // Append the next character to the displayed text
            currentCharIndex++; // Move to the next character
            lastCharTime = Time.time; // Update the last character time
        }
    }

    private void UpdateTimeText(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000f);

        timeText.text = string.Format("Your time: {0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }

    private void UpdateBestTimeText()
    {
        int minutes = Mathf.FloorToInt(bestTime / 60f);
        int seconds = Mathf.FloorToInt(bestTime % 60f);
        int milliseconds = Mathf.FloorToInt((bestTime * 1000) % 1000f);

        bestTimeText.text = string.Format("Best time: {0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
