using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float initTimeValue = 150;
    float timeValue;
    [SerializeField] TextMeshProUGUI timerText;

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = initTimeValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0) {
            timeValue -= Time.deltaTime;
            GameManager.endGame = false;  
        } else {
            timeValue = 0;

            if (!GameManager.endGame) {
                gameManager.EndGame();
                Destroy(gameObject); // prevent EndGame() from triggering again right before restart
            }
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float time) {
        if (time < 0) {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        //float milliseconds = time % 1 * 1000;

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        //timerText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
