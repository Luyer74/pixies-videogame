using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText = null;
    [SerializeField] private Slider slider = null;
   

    private bool decreaseTimer = true;
    [SerializeField] private int minutes = 1;
    [SerializeField] private int seconds = 0;
    [SerializeField] private bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
        if (decreaseTimer && !endGame)
        {
            seconds -= 1;
            if (seconds < 0)
            {
                minutes -= 1;
                if (minutes < 0)
                {
                    minutes = 0;
                    seconds = 0;
                    endGame = true;
                }
                else
                {
                    seconds = 59; 
                }
            }
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
            StartCoroutine(second_counter());
        }
    }

    IEnumerator second_counter()
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
}