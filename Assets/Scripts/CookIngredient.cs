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
    GameObject ingrediente;
    int tomatos = 0;
    int onions = 0;
    int mushrooms = 0;
    public int ingredientCount = 0; //ingredientes en uso
    public ParticleSystem particles;
    public bool isCooking = false;
    bool goodSoup = true;
    public bool finishedSoup = false;
    public bool soupExpired = false;
    public float expiredStartTime = 0f;
    public float expiredTimer = 0f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        player1 = collision.GetComponent<PlayerInteract>(); //obtener objeto para usar las funciones de playerinteract
        if (player1)
        {
            isInRange = true;
        }
        if (player.transform.childCount > 0)
        {
            ingrediente = player.transform.GetChild(0).gameObject;
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
        if (isInRange && ingrediente && Input.GetKeyDown(intkey))
        {
            if (ingrediente.CompareTag("Ingredient") && ingredientCount < 3 && !finishedSoup)
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
                if (!player1.isSliced) goodSoup = false; //si no esta cortado, sopa mala
                if (ingrediente.name == "Tomato(Clone)") tomatos++;
                else if (ingrediente.name == "Onion(Clone)") onions++;
                else if (ingrediente.name == "Mushroom(Clone)") mushrooms++;
                ingredientCount++;
                player1.cook(); //llamar a player interact con el objeto con el que se interactua
            }
            else if (ingrediente.CompareTag("Plate") && finishedSoup && !player1.isCooked)
            {
                if (goodSoup)
                {
                    if (ingredientCount != 3) goodSoup = false; //si no usa 3 ingredientes, sopa mala
                    else
                    {
                        goodSoup = !soupExpired && checkIngredients(tomatos, onions, mushrooms); //si no sigue receta, sopa mala
                    }
                }

                player1.getSoup(goodSoup, tomatos, onions, mushrooms); //cambiar sprite del plato con sopa
                finishedSoup = false;
                ingredientCount = 0;
                tomatos = 0;
                onions = 0;
                mushrooms = 0;
            }
        }

        if (isCooking)
        {
            soupExpired = false;
            timer += Time.deltaTime;
            timeBar.fillAmount = 1 - ((timer - startTime) / holdTime);
            if (timer > (startTime + holdTime))
            {
                finishedSoup = true;
                imagen.SetActive(false);
                timeBar.fillAmount = 1; //barra vacia
                isCooking = false;
                fire.SetActive(false);
                expiredStartTime = Time.time;
                expiredTimer = expiredStartTime;
            }
        }

        if(finishedSoup)
        {
            expiredTimer += Time.deltaTime;
            if(expiredTimer - expiredStartTime > 10)
            {
                Debug.Log("EXPIRED");
                soupExpired = true;
            }
        }
    }

    private bool checkIngredients(int tomatos, int onions, int mushrooms)
    {
        if (tomatos == 3 || onions == 3 || mushrooms == 3) return true;
        else if (tomatos == 2 && mushrooms == 1) return true;
        return false;
    }

    private void Start()
    {
        imagen.SetActive(false);
        timeBar = imagen.GetComponent<Image>();

    }
}


