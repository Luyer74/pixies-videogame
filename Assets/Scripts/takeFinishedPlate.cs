using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeFinishedPlate : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    PlayerInteract player1; //script para interactuar con objetos
    GameObject player;
    public GameObject ingrediente;

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

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(intkey) && ingrediente && player1.isCooked == true)
        {
            player1.finish();
        }
    }
}
