using UnityEngine;
using TMPro;

public class DelayedTextActivation : MonoBehaviour
{
    public float delay = 4f;
    private TMP_Text textComponent;
    private float elapsedTime;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        SetTextOpacity(0f);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime <= delay)
        {
            float opacity = Mathf.Lerp(0f, 1f, elapsedTime / delay);
            SetTextOpacity(opacity);
        }
        else
        {
            SetTextOpacity(1f);
        }
    }

    private void SetTextOpacity(float opacity)
    {
        Color color = textComponent.color;
        color.a = opacity;
        textComponent.color = color;
    }
}
