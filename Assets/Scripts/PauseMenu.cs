using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuButton;
    public GameObject gameUI;
    public TMP_Text highScoreText;
    public bool endGame;
    GameTimer timer;

    void Start()
    {
        timer = GameObject.FindObjectOfType(typeof(GameTimer)) as GameTimer;
        endGame = false;
    }

    void Update()
    {
        endGame = timer.GetEndGame();
        if (Input.GetKeyDown(KeyCode.Escape) && !endGame)
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameUI.SetActive(true);
        pauseMenuButton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        timer.second_counter();
    }

    public void Pause()
    {
        gameUI.SetActive(false);
        pauseMenuButton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("highScore");
        highScoreText.text = "0";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
