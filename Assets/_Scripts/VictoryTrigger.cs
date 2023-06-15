using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("LoadVictoryScene", 1f);
        }
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory");
    }
}
