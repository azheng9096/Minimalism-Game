using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesManager : MonoBehaviour
{
    public float gravity = 0.1f;

    public delegate void OnGravityChanged();
    public OnGravityChanged GravityChangedCallback;

    [SerializeField] float changeGravityRepeatRate = 15f;
    [SerializeField] float incGravityAmt = 0.1f;
    [SerializeField] float maxGravity = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        // Ideally InvokeRepeating delay value = ([ShapeSpawner InvokeRepeating delay value] + changeGravityRepeatRate)
        InvokeRepeating("ChangeGravity", 16f, changeGravityRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGravity(float newGravity) {
        gravity = newGravity;

        GravityChangedCallback?.Invoke();
    }

    public void ChangeGravity() {
        float newGravity = gravity + incGravityAmt;

        if (newGravity <= maxGravity) {
            SetGravity(newGravity);
        } else {
            SetGravity(maxGravity);
        }
    }
}
