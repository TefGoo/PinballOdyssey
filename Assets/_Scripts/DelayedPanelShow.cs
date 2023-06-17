using UnityEngine;

public class DelayedPanelShow : MonoBehaviour
{
    public GameObject panel;
    public float delayDuration = 25f;

    private float startTime;

    private void Start()
    {
        startTime = Time.time;
        panel.SetActive(false); // Initially hide the panel
    }

    private void Update()
    {
        if (Time.time - startTime >= delayDuration && !panel.activeSelf)
        {
            panel.SetActive(true); // Show the panel
            enabled = false; // Disable the script after showing the panel
        }
    }
}
