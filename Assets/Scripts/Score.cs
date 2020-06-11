using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    GameTimer timer;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("highScore", 0).ToString();
        timer = GameObject.FindObjectOfType(typeof(GameTimer)) as GameTimer;
    }

    public void AddScore()
    {
        score = score + 10;
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = score.ToString();
        }
        timer.AddSeconds();
    }

    public void SubtractScore()
    {
        score = score - 10;
        scoreText.text = score.ToString();
        timer.SubtractSeconds();
    }

    public int GetScore()
    {
        return score;
    }
}
