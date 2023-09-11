using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour

{
    float timer;
    public GameObject slime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            Instantiate(slime, transform.position, transform.rotation);
            timer = Random.Range(0, 1) + 0.9f;
        }
    }
}
