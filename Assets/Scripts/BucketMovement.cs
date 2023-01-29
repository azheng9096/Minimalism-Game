using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketMovement : MonoBehaviour
{
    public float speed = .5f;
    public float distance = 5;
    private float startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.SmoothStep(startPosition, startPosition + distance, Mathf.PingPong(Time.time * speed, 1));
        transform.position = newPosition;

    }
}
