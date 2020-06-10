using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookIngredient : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    PlayerInteract player1; //script para interactuar con objetos

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
                player1.getIngredient(gameObject); //llamar a player interact con el objeto con el que se interactua
            }
        }
    }
}
