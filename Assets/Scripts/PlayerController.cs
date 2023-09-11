using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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

    //handles jump height
    public float initialJumpForce = 7; // Adjust this value for your starting jump force
    public float maxJumpForce = 21.0f; // Adjust this value for your maximum jump force
    public float jumpForceIncreaseRate = 0.1f; // Adjust this value for the rate of jump force increase
    private float currentJumpForce;


    private Rigidbody2D rb;
    private bool canJump = true;

    public float initialGravity = 1.0f; // Adjust this value for your starting gravity
    public float maxGravity = 3.0f; // Adjust this value for your maximum gravity
    public float gravityIncreaseRate = 0.1f; // Adjust this value for the rate of gravity increase
    private float currentGravity;

    private ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameTimer = 1f / framesPerSecond;
        currentFrameIndex = 0;
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<ScoreManager>();

        currentGravity = initialGravity; // Set the initial gravity.
        rb.gravityScale = currentGravity; // Apply the initial gravity to the player.

        currentJumpForce = initialJumpForce;
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
        if (scoreManager != null && scoreManager.IsGameStarted())
        {
            UpdateJumpForce();
            UpdateGravity();
        }
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

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,currentJumpForce);
        canJump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }


    void UpdateJumpForce()
    {
        if (scoreManager != null)
        {
            // Get the current score from the ScoreManager
            int score = scoreManager.GetScore();

            // Calculate the new jump force based on the score
            currentJumpForce = Mathf.Clamp(initialJumpForce + jumpForceIncreaseRate * score, initialJumpForce, maxJumpForce);
        }
    }
    void UpdateGravity()
    {
        if (scoreManager != null)
        {
            // Get the current score from the ScoreManager
            int score = scoreManager.GetScore();

            // Calculate the new gravity based on the score
            currentGravity = Mathf.Clamp(initialGravity + gravityIncreaseRate * score, initialGravity, maxGravity);

            // Apply the updated gravity to the player's rigidbody
            rb.gravityScale = currentGravity;
        }
    }
}

