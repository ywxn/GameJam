using UnityEngine;

public class BounceScript : MonoBehaviour
{
    public float speed = 5.0f; // Adjust the speed as needed
    private Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized; // Start with a random direction
    }

    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        // Check if the sprite hits the screen edges
        if (screenPoint.x < 0 || screenPoint.x > 1)
        {
            direction.x = -direction.x; // Reverse the x direction
        }

        if (screenPoint.y < 0 || screenPoint.y > 1)
        {
            direction.y = -direction.y; // Reverse the y direction
        }

        // Move the sprite
        rb.velocity = direction * speed;
    }
}
