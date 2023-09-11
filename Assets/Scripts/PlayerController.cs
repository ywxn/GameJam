using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Sprite[] run;
    public Sprite[] jumpUp;
    public Sprite[] jumpDown;

    SpriteRenderer spriteRenderer;

    public float framesPerSecond = 15;

    int currentFrameIndex = 0;
    float frameTimer;

    public float jumpForce = 10f; // Adjust this value to control the jump height
    private Rigidbody2D rb;
    private bool canJump = true;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameTimer = 1f / framesPerSecond;
        currentFrameIndex = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer += Time.deltaTime;
        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            canJump = false;
        }
        if (rb.velocity.y > 0)
        {
            Animate(jumpUp);
        }
        if (rb.velocity.y < 0)
        {
            Animate(jumpDown);
        }
        else
        {
            Animate(run);
        }

        void Animate(Sprite[] frames)
        {
            //if (frames.Length == 0)
            //{
                // Ensure there are frames to animate.
            //    return;
            //}

            if (frameTimer >= (1f / framesPerSecond))
            {
                frameTimer = 0;
                currentFrameIndex = (currentFrameIndex + 1) % frames.Length;
                // Update the sprite and flipX property based on the current frame.
                spriteRenderer.sprite = frames[currentFrameIndex];
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        canJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

}

