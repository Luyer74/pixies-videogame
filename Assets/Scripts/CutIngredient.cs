using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

public class CutIngredient : MonoBehaviour
{
    public GameObject imagen; //barra de tiempo
    Image timeBar;
    public bool isInRange;
    bool moved = false;
    public KeyCode intkey;
    PlayerInteract cutStation;
    GameObject player;
    GameObject ingrediente;
    public float startTime = 0f; //tiempo de inicio de presionar tecla
    public float timer = 0f;
    public float holdTime = 5.0f; //tiempo requerido para "cortar"
    public bool held = false;
    public GameObject sonidocortar;
    GameObject clone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        //checar si el jugador tiene un ingrediente
        if (player.transform.childCount > 0)
        {
            ingrediente = player.transform.GetChild(0).gameObject;
        }
        cutStation = collision.GetComponent<PlayerInteract>(); //obtener objeto para usar las funciones de playerinteract
        if (cutStation)
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            held = false;
            timeBar.fillAmount = 0; //barra vacia
            imagen.SetActive(false);
            if (moved)
            {
                ingrediente.transform.position = ingrediente.transform.position + new Vector3(-1, 0);
                moved = false;
            }
        }
    }

    private void Start()
    {
        imagen.SetActive(false);
        timeBar = imagen.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isInRange && ingrediente)
        {
            if (ingrediente.CompareTag("Ingredient") && !cutStation.isSliced)
            {
                if (Input.GetKeyDown(intkey))
                {
                    clone = Instantiate(sonidocortar);
                    moved = true;
                    ingrediente.transform.position = ingrediente.transform.position + new Vector3(1, 0);

                    imagen.SetActive(true);
                    startTime = Time.time;
                    timer = startTime;

                }


                if (Input.GetKey(intkey) && held == false)
                {
                    timer += Time.deltaTime;
                    timeBar.fillAmount = (timer - startTime) / holdTime; //llenar barra de tiempo mientras se siga presionando
                    if (timer > (startTime + holdTime))
                    {
                        //se corta el ingrediente
                        held = true;
                        cutStation.useIngredient(gameObject);
                    }
                }
            }

            if (Input.GetKeyUp(intkey))
            {
                Destroy(clone);
                if (ingrediente && moved)
                {
                    ingrediente.transform.position = ingrediente.transform.position + new Vector3(-1, 0);
                    moved = false;
                }

                timeBar.fillAmount = 0; //barra vacia
                held = false;
                imagen.SetActive(false);
            }
        }
    }
}
