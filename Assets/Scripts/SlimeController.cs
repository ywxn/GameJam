using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class SlimeController : MonoBehaviour

{
    public Sprite[] slimeIdle;
    //publci Sprite[] stimeJump;

    SpriteRenderer spriteRenderer;
    public float framesPerSecond = 15;

    int currentFrameIndex = 0;
    float frameTimer;

    private Rigidbody2D rb;

    public float speed = 1f; 
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;
        vel.x = -speed;
        rb.velocity = vel;
        frameTimer += Time.deltaTime;
        Animate(slimeIdle);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
