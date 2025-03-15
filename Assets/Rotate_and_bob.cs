using UnityEngine;

public class Rotate_and_bob : MonoBehaviour
{
    public float rotateSpeed;

    // Bobbing variables
    public float speed = 2f;
    public float height = 0.5f;

    private float baseHeight;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position; // Store initial position
        baseHeight = startPos.y; // Set base height
    }

    private void FixedUpdate()
    {
        // Rotate the coin
        transform.Rotate(0, 0, rotateSpeed); // Y-axis spin

        // Bobbing effect
        float newY = baseHeight + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
