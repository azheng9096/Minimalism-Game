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
        
    }
}
