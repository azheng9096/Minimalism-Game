using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGravityScale(float g) {
        rb.gravityScale += g;
    }

    public void SetGravityScale(float g) {
        rb.gravityScale = g;
    }
}
