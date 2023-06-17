using UnityEngine;
using UnityEngine.UI;

public class FadeInPanel : MonoBehaviour
{
    public float fadeDuration = 30f; // Duration in seconds for the fade-in effect

    private Image panelImage;
    private float currentAlpha = 0f;
    private float targetAlpha = 1f;
    private float fadeStartTime;

    private void Start()
    {
        panelImage = GetComponent<Image>();
        panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, currentAlpha);
        fadeStartTime = Time.time;
    }

    private void Update()
    {
        float timeElapsed = Time.time - fadeStartTime;
        if (timeElapsed < fadeDuration)
        {
            currentAlpha = Mathf.Lerp(0f, 1f, timeElapsed / fadeDuration);
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, currentAlpha);
        }
        else
        {
            currentAlpha = targetAlpha;
            panelImage.color = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, currentAlpha);
            enabled = false; // Disable the script once the fade-in is complete
        }
    }
}
