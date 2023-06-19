using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 2f;
    public float minX = -4f;
    public float maxX = 4f;
    private float targetX;
    private float startX;

    private void Start()
    {
        targetX = maxX;
        startX = transform.position.x;
    }

    private void Update()
    {
        float newX = Mathf.PingPong((Time.time * speed) + startX, maxX - minX) + minX;
        Vector3 newPosition = transform.position;
        newPosition.x = newX;
        transform.position = newPosition;

        if (newX == minX || newX == maxX)
        {
            targetX = (targetX == maxX) ? minX : maxX;
        }
    }
}
