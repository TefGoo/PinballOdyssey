using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game...");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
