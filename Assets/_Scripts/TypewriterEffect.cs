using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float delayBetweenCharacters = 0.05f; // Delay between each character being "typed"
    public string fullText = "victory"; // The full text to be displayed
    private string currentText = ""; // The text that is currently displayed
    private float lastCharTime; // The time when the last character was displayed
    private int currentCharIndex; // The index of the current character being displayed
    private TMP_Text textComponent; // Reference to the Text component

    private void Awake()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        lastCharTime = Time.time;
    }

    private void Update()
    {
        if (currentCharIndex < fullText.Length)
        {
            // Check if enough time has passed to display the next character
            if (Time.time - lastCharTime > delayBetweenCharacters)
            {
                currentText += fullText[currentCharIndex]; // Append the next character to the current text
                textComponent.text = currentText; // Update the text component

                currentCharIndex++; // Move to the next character
                lastCharTime = Time.time; // Update the last character time
            }
        }
    }
}
