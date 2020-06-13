using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText = null;
    [SerializeField] private Slider slider = null;
   
    private bool decreaseTimer = true;
    [SerializeField] private int minutes ;
    [SerializeField] private int seconds;
    [SerializeField] private int totalSeconds;
    [SerializeField] private bool endGame = false;
    public GameObject successSound;
    public GameObject failureSound;
    public GameObject GameUI;
    public GameObject PauseUI;
    public GameObject EndGameSuccessUI;
    public GameObject EndGameFailureUI;
    public int totalScore;
    public int highScore;
    Score score;

    void Start()
    {
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;
    }

    void Update()
    {
        if(decreaseTimer && !endGame)
        {
            totalSeconds -= 1;
            if(totalSeconds < 0)
            {
                minutes = 0;
                seconds = 0;
		endGame = true;
            }
            else
            {
                minutes = totalSeconds / 60;
                seconds = totalSeconds % 60;
            }
            if (seconds > 9) timerText.text = minutes.ToString() + ":" + seconds.ToString();
            else timerText.text = minutes.ToString() + ":0" + seconds.ToString();
            StartCoroutine(second_counter());
        }
        else if(endGame)
        {
            EndGame();
        }
    }

    public IEnumerator second_counter()
    {
        decreaseTimer = false;
        yield return new WaitForSeconds(1);
        decreaseTimer = true;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int maxhp)
    {
        slider.maxValue = maxhp;
    }

    public void increaseTimer(int sec)
    {
        seconds += sec;
    }


    public void EndGame()
    {
        GameUI.SetActive(false);
        PauseUI.SetActive(false);
        totalScore = score.GetScore();
        highScore = PlayerPrefs.GetInt("highScore", 0);
        if (totalScore >= highScore)
        {
            EndGameSuccessUI.SetActive(true);
            Instantiate(successSound);
        }
        else
        {
            EndGameFailureUI.SetActive(true);
            Instantiate(failureSound);
        }
    }

    public bool GetEndGame()
    {
        return endGame;
    }

    public void AddSeconds()
    {
        totalSeconds = totalSeconds + 20;
    }

    public void SubtractSeconds()
    {
        totalSeconds = totalSeconds - 10;
    }
}