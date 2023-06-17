using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject optionsPanel;

    private bool isPaused = false;

    private void Start()
    {
        // Hide both the pause menu canvas and the options panel at the start
        pauseMenuCanvas.SetActive(false);
        optionsPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if the player presses the "Esc" key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause state
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        // Pause the game and show the pause menu canvas
        Time.timeScale = 0f;
        pauseMenuCanvas.SetActive(true);
    }

    public void ResumeGame()
    {
        // Resume the game, hide the pause menu canvas, and hide the options panel
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void ShowOptionsPanel()
    {
        // Show the options panel and hide the pause menu canvas
        optionsPanel.SetActive(true);
        pauseMenuCanvas.SetActive(false);
    }

    public void CloseOptionsPanel()
    {
        // Show the pause menu canvas and hide the options panel
        optionsPanel.SetActive(false);
        pauseMenuCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        // Quit the game (only works in standalone builds, not in the Unity Editor)
        Application.Quit();
    }
}
