using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesSpawner : MonoBehaviour
{
    // spawnpoint
    public float left = -8, right = 8, top = 12, bottom = 8;

    // frequency - will spawn shape every repeatRate seconds
    public float repeatRate = 2.5f;

    // change repeat rate
    [SerializeField] float changeRepeatRateFactor = 0.5f;
    [SerializeField] float changeRepeatRateAmt = 0.5f;
    [SerializeField] float minRepeatRate = 0.25f;
    [SerializeField] float changeRepeatRateFreq = 20f;


    // color palette
    string[] colors = {"7DCD85", "F06543", "38023B", "03F7EB", "AB2346", 
        "00B295", "F09D51", "F9B5AC", "EE7674"};

    // shapes pool
    [SerializeField] GameObject[] shapes;

    // Start is called before the first frame update
    void Start()
    {
        // InvokeRepeating("ChangeSpawnRateByFactor", 1f + changeRepeatRateFreq, changeRepeatRateFreq);
        InvokeRepeating("ChangeSpawnRate", 1f + changeRepeatRateFreq, changeRepeatRateFreq);
        InvokeRepeating("SpawnShape", 1f, repeatRate);
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

    void ChangeSpawnRateByFactor() {
        CancelInvoke("SpawnShape");
        
        // calculate new repeatRate
        float newRepeatRate = repeatRate * changeRepeatRateFactor;
        if (newRepeatRate >= minRepeatRate) {
            repeatRate = newRepeatRate;
        }

        InvokeRepeating("SpawnShape", 0f, repeatRate);
    }

    void ChangeSpawnRate() {
        CancelInvoke("SpawnShape");
        
        // calculate new repeatRate
        float newRepeatRate = repeatRate - changeRepeatRateAmt;

        if (newRepeatRate <= 1) {
            changeRepeatRateAmt = 0.25f;
        }

        if (newRepeatRate >= minRepeatRate) {
            repeatRate = newRepeatRate;
        } else {
            repeatRate = minRepeatRate;
        }

        InvokeRepeating("SpawnShape", 2f, repeatRate);
    }
}
