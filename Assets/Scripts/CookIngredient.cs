using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookIngredients : MonoBehaviour
{
    public GameObject imagen1;
    public GameObject imagen2;
    public GameObject imagen3;

    //Barra de sartenes
    private Image timeBar1;
    private Image timeBar2;
    private Image timeBar3;

    private float timer1 = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;
    private float cookTime = 5.0f; //tiempo requerido para "cocinar"

    private bool isCooking1 = false;
    private bool isCooking2 = false;
    private bool isCooking3 = false;

    private float startTime1;
    private float startTime2;
    private float startTime3;

    private void Start()
    {
        imagen1.SetActive(false);
        timeBar1 = imagen1.GetComponent<Image>();

        imagen2.SetActive(false);
        timeBar2 = imagen2.GetComponent<Image>();

        imagen3.SetActive(false);
        timeBar3 = imagen3.GetComponent<Image>();
    }

    public void cookIngredient(int num)
    {
        if (num == 1)
        {
            isCooking1 = true;
            startTime1 = Time.time;
            timer1 = startTime1;
            imagen1.SetActive(true);
            Debug.Log("Cook 1");
        }
        else if (num == 2)
        {
            isCooking2 = true;
            startTime2 = Time.time;
            timer2 = startTime2;
            imagen2.SetActive(true);
            Debug.Log("Cook 2");
        }
        else{
            isCooking3 = true;
            startTime3 = Time.time;
            timer3 = startTime3;
            imagen3.SetActive(true);
            Debug.Log("Cook 3");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isCooking1)
        {
            timer1 += Time.deltaTime;
            timeBar1.fillAmount = (timer1 - startTime1) / cookTime; //llenar barra de tiempo mientras se siga presionando
            if (timer1 > (startTime1 + cookTime))
            {
                timeBar1.fillAmount = 0; //barra vacia
                imagen1.SetActive(false);
                isCooking1 = false;
            }
        }

        if (isCooking2)
        {
            timer2 += Time.deltaTime;
            timeBar2.fillAmount = (timer2 - startTime2) / cookTime; //llenar barra de tiempo mientras se siga presionando
            if (timer2 > (startTime2 + cookTime))
            {
                timeBar2.fillAmount = 0; //barra vacia
                imagen2.SetActive(false);
                isCooking2 = false;
            }
        }

        if (isCooking3)
        {
            timer3 += Time.deltaTime;
            timeBar3.fillAmount = (timer3 - startTime3) / cookTime; //llenar barra de tiempo mientras se siga presionando
            if (timer3 > (startTime3 + cookTime))
            {
                timeBar3.fillAmount = 0; //barra vacia
                imagen3.SetActive(false);
                isCooking3 = false;
            }
        }
    }
}

