using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPlate : MonoBehaviour
{
    public bool isInRange; //esta en rango con alguhn objeto
    public KeyCode intkey; // tecla "E"
    public bool available = true;
    public GameObject sprite;
    public int used = 0;
    public Sprite dirtyPlateSprite;
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

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(intkey))
            {
                if (available == true && player1.GetComponent<PlayerInteract>().hasObject == false)
                {
                    available = false;
                    sprite.SetActive(false);
                    player1.getIngredient(gameObject); //llamar a player interact con el objeto con el que se interactua
                    used++;
                    StartCoroutine(ExampleCoroutine());
                }
            }
        }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(15);
        available = true;
        sprite.GetComponent<SpriteRenderer>().sprite = dirtyPlateSprite;
        sprite.SetActive(true);
    }
}
