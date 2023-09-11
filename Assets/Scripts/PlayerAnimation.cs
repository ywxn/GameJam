using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerAnimation : MonoBehaviour
{
    public Sprite[] run;
    public Sprite[] jump;

    SpriteRenderer spriteRenderer;

    public float framesPerSecond = 15;

    int currentFrameIndex = 0;
    float frameTimer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameTimer = 1f / framesPerSecond;
        currentFrameIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            Animate(jump);
        }
        else
        {
            Animate(run);
        }

        void Animate(Sprite[] frames)
        {
            if (frames.Length == 0)
            {
                // Ensure there are frames to animate.
                return;
            }

            if (frameTimer >= (1f / framesPerSecond))
            {
                frameTimer = 0;
                currentFrameIndex = (currentFrameIndex + 1) % frames.Length;

                // Update the sprite and flipX property based on the current frame.
                spriteRenderer.sprite = frames[currentFrameIndex];
            }
        }
    }
}

