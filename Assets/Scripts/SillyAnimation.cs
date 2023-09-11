using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SillyAnimation : MonoBehaviour
{
    public Sprite[] anim;

    SpriteRenderer spriteRenderer;
    public float framesPerSecond = 15;

    int currentFrameIndex = 0;
    float frameTimer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        frameTimer += Time.deltaTime;
        Animate(anim);        
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
