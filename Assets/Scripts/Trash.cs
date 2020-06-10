using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    GameObject player; 
    GameObject ingrediente;
    PlayerInteract player1;
    public GameObject SonidoSoltar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        player1 = player.GetComponent<PlayerInteract>();
        
        //checar si el jugador tiene un ingrediente
        if (player.transform.childCount > 0)
        {
            ingrediente = player.transform.GetChild(0).gameObject;
        }
        if (player)
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
                player1.hasObject = false;
                Instantiate(SonidoSoltar);
                Destroy(ingrediente);
                Debug.Log("Tirado a la basura");
            }
        }
    }
}
