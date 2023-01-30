using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    // shapes pool
    [System.Serializable]
    struct Shape {
        public string name;
        public GameObject icon;
    }

    [SerializeField] Shape[] shapes;

    int currShape = 0;


    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currShape = (currShape + 1) % (shapes.Length);
            SetBucketShape(currShape);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(shapes[currShape].name)) {
            gameManager.score++;
            Destroy(other.gameObject);
        } else {
            Destroy(other.gameObject);
            gameManager.EndGame();
        }
        
    }

    void SetBucketShape(int shapeInd) {
        currShape = shapeInd;

        for (int i = 0; i < shapes.Length; i++) {
            if (i == shapeInd) {
                (shapes[i].icon).SetActive(true);
                continue;
            }

            (shapes[i].icon).SetActive(false);
        }
    }
    
}
