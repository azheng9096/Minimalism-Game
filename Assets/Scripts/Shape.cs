using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    ShapesManager shapesManager;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
        GameObject shapesManagerObject = GameObject.FindGameObjectWithTag("ShapesManager");
        if (shapesManagerObject) {
            shapesManager = shapesManagerObject.GetComponent<ShapesManager>();
        }

        shapesManager.GravityChangedCallback += SetGravityScaleBySM;

        // init set gravity
        SetGravityScale(shapesManager.gravity);
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

    public void SetGravityScaleBySM() {
        SetGravityScale(shapesManager.gravity);
    }
}
