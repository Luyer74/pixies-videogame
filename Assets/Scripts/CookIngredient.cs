using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookIngredient : MonoBehaviour
{
    public GameObject imagen; //barra de tiempo
    Image timeBar;
    public float timer = 0f;
    public float holdTime = 15.0f; //tiempo requerido para cocinar
    public float startTime = 0f;
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    PlayerInteract player1; //script para interactuar con objetos
    GameObject player;
    GameObject fire;
    int ingredientCount;
    public ParticleSystem particles;

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
        if (isInRange)
        {
            if (Input.GetKeyDown(intkey) && player1.hasObject)
            {
                fire = gameObject.transform.GetChild(0).gameObject;
                fire.SetActive(true);
                particles = fire.GetComponent<ParticleSystem>();
                if (!particles.isPlaying)
                {
                    particles.Play();
                }
                player1.cook(gameObject); //llamar a player interact con el objeto con el que se interactua
            }
        }
    }
}
