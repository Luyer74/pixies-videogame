using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GetIngredient : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    PlayerInteract player1; //script para interactuar con objetos
    public float startTime = 0f; //tiempo de inicio de presionar tecla
    public float timer = 0f;
    public float holdTime = 5.0f; //tiempo requerido para "cortar"
    public bool held = false; //
    private void OnTriggerEnter2D(Collider2D collision)
    {
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
            if (Input.GetKeyDown(intkey))
            {
                startTime = Time.time;
                timer = startTime;
                player1.getIngredient(gameObject); //llamar a player interact con el objeto con el que se interactua
            }

            if(Input.GetKey(intkey) && held == false)
            {
                timer += Time.deltaTime;

                if(timer > (startTime + holdTime))
                {
                    held = true;
                    player1.useIngredient(gameObject);
                }
            }

            if (Input.GetKeyUp(intkey))
            {
                held = false;
            }
        }
    }
}
