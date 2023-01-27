using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesSpawner : MonoBehaviour
{
    // spawnpoint
    public float left = -8, right = 8, top = 12, bottom = 8;

    // frequency - will spawn shape every repeatRate seconds
    public float repeatRate = 4f;

    // color palette
    [SerializeField] string[] colors = {"7DCD85", "80AB82", "778472", 
        "987284", "9DBF9E", "D0D6B5", "F9B5AC", "EE7674"};

    // shapes pool
    [SerializeField] GameObject[] shapes;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnShape", 2f, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnShape() {
        float randomXPos = Random.Range(left, right);
        float randomYPos = Random.Range(bottom, top);
        Vector2 spawnPosition = new Vector2(randomXPos, randomYPos);

        float randomZRot = Random.Range(0f, 360f);

        // spawn shape
        int randomShapeInd = Random.Range(0, shapes.Length);
        GameObject shape = Instantiate(shapes[randomShapeInd], spawnPosition, Quaternion.Euler(0f, 0f, randomZRot));


        // set color
        int randomColorInd = Random.Range(0, colors.Length);

        Color color;
        if(ColorUtility.TryParseHtmlString("#" + colors[randomColorInd], out color)) {
            shape.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
