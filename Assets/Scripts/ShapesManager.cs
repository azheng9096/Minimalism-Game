using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesManager : MonoBehaviour
{
    public float gravity = 0.15f;

    public delegate void OnGravityChanged();
    public OnGravityChanged GravityChangedCallback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGravity(float newGravity) {
        gravity = newGravity;

        GravityChangedCallback?.Invoke();
    }
}
