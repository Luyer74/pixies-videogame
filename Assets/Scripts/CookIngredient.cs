using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookIngredient : MonoBehaviour
{
    public GameObject imagen; //barra de tiempo
    Image timeBar;
    public float timer = 0f;
    public float holdTime = 20.00f; //tiempo requerido para cocinar
    public float startTime = 0f;
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    PlayerInteract player1; //script para interactuar con objetos
    GameObject player;
    GameObject fire;
    public int ingredientCount = 0; //ingredientes en uso
    public ParticleSystem particles;
    bool isCooking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        player1 = collision.GetComponent<PlayerInteract>(); //obtener objeto para usar las funciones de playerinteract
        if (player1)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange && ingredientCount < 3)
        {
            if (Input.GetKeyDown(intkey) && player1.hasObject && player1.objectType == "ingredient")
            {
                if (!isCooking)
                {
                    imagen.SetActive(true);
                    startTime = Time.time;
                    timer = startTime;
                    isCooking = true;
                    fire = gameObject.transform.GetChild(0).gameObject;
                    fire.SetActive(true);
                    particles = fire.GetComponent<ParticleSystem>();
                    particles.Play();
                }
                ingredientCount++;
                player1.cook(gameObject); //llamar a player interact con el objeto con el que se interactua
            }
        }

        if (isCooking)
        {
            timer += Time.deltaTime;
            timeBar.fillAmount = 1 - ((timer - startTime) / holdTime);
        }

        if (timer > (startTime + holdTime))
        {
            imagen.SetActive(false);
            timeBar.fillAmount = 1; //barra vacia
            ingredientCount = 0;
            isCooking = false;
            fire.SetActive(false);
        }
    }

    private void Start()
    {
        imagen.SetActive(false);
        timeBar = imagen.GetComponent<Image>();
    }
}
