using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI onScreenScoreText;
    [SerializeField] TextMeshProUGUI onScreenHighScoreText;

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject EndMenu;

    public static bool isPaused = false;
    public static bool endGame = false;


    [Header("End Menu Text")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI recordedHighScoreText;
    [SerializeField] GameObject newHighScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (onScreenHighScoreText != null) {
            onScreenHighScoreText.text = (PublicVars.highScore).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!endGame && Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }

        onScreenScoreText.text = score.ToString();
    }

    
    public void ResumeGame() {
        PauseMenu.SetActive(false);
        EndMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        endGame = false;
    }

    public void PauseGame() {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void EndGame() {
        Time.timeScale = 0f;
        endGame = true;
        isPaused = true;

        EndMenu.SetActive(true);

        // get and display scores
        scoreText.text = score.ToString();
        recordedHighScoreText.text = (PublicVars.highScore).ToString();

        // set and display new high score if necessary
        if (score > PublicVars.highScore) {
            PublicVars.highScore = score;
            newHighScoreText.SetActive(true);
        } else {
            newHighScoreText.SetActive(false);
        }
    }

    public void Retry() {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        ResumeGame();
        SceneManager.LoadScene("MainMenu");
    }
}
