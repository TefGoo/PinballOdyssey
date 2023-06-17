using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas;
    public string playerPrefsKey = "CanvasShown";

    private bool isCanvasShown = false;

    private void Start()
    {
        // Check if the canvas has been shown before
        isCanvasShown = PlayerPrefs.GetInt(playerPrefsKey, 0) == 1;

        // If the canvas has not been shown before, show it and set the time scale to 0
        if (!isCanvasShown)
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
        }
        else
        {
            // If the canvas has been shown before, hide it and set the time scale to 1
            Time.timeScale = 1f;
            canvas.SetActive(false);
        }
    }

    public void DeactivateCanvas()
    {
        // Set the canvas as shown in PlayerPrefs, hide it, and set the time scale to 1
        PlayerPrefs.SetInt(playerPrefsKey, 1);
        canvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
