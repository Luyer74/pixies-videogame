using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterInteract : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    public bool available; //hay o no objeto
    GameObject obj;
    GameObject player;
    SpriteRenderer spr;
    public bool isSliced = false;
    public bool clean = false;
    public bool isCooked = false;
    PlayerInteract player1; //script para interactuar con objetos

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
            obj = player.transform.GetChild(0).gameObject;
        }
        else if (gameObject.transform.childCount > 0)
        {
            obj = gameObject.transform.GetChild(0).gameObject;
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
        if (isInRange && Input.GetKeyDown(intkey) && obj)
        {
            spr = obj.GetComponentInChildren<SpriteRenderer>();
            if (available && player1.hasObject)
            {
                spr.sortingOrder = 2;
                obj.transform.SetParent(gameObject.transform, false); //cambiar posicion
                isSliced = player1.isSliced;
                clean = player1.clean;
                isCooked = player1.isCooked;
                available = false;
                player1.ingrediente = null;
                player1.hasObject = false;
                player1.isSliced = false;
                player1.clean = false;
            }
            else if(!available && !player1.hasObject)
            {
                obj.transform.SetParent(player.transform, false);
                spr.sortingOrder = 3;
                player1.ingrediente = obj;
                player1.hasObject = true;
                player1.isSliced = isSliced;
                player1.isCooked = isCooked;
                player1.clean = clean;
                available = true;
                isSliced = false;
                clean = false;
                isCooked = false;
            }
        }
    }
}
