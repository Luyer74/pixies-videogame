using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

public class cleanPlate : MonoBehaviour
{
    public GameObject imagen; //barra de tiempo
    Image timeBar;
    public bool isInRange;
    bool moved = false;
    public KeyCode intkey;
    PlayerInteract washStation;
    GameObject player;
    GameObject plate;
    public float startTime = 0f; //tiempo de inicio de presionar tecla
    public float timer = 0f;
    public float holdTime = 5.0f; //tiempo requerido para "cortar"
    public bool held = false;
    public GameObject SonidoLavar;
    GameObject clonel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        //checar si el jugador tiene un ingrediente
        if (player.transform.childCount > 0)
        {
            plate = player.transform.GetChild(0).gameObject;
            print("ingrediente: " + plate.name);
        }
        washStation = collision.GetComponent<PlayerInteract>(); //obtener objeto para usar las funciones de playerinteract
        if (washStation)
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
                plate.transform.position = plate.transform.position + new Vector3(-1, 0);
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
         if (isInRange)
        {
            
            if (plate && plate.CompareTag("Plate") && !washStation.isCooked)
            {
                if (Input.GetKeyDown(intkey))
                {
                    clonel = Instantiate(SonidoLavar);
                    moved = true;
                    plate.transform.position = plate.transform.position + new Vector3(0, 1);

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
                        //se lava el ingrediente
                        held = true;
                        washStation.washPlate();
                    }
                }
            }

            if (Input.GetKeyUp(intkey))
            {
                if (plate && moved)
                {
                    Destroy(clonel);
                    plate.transform.position = plate.transform.position + new Vector3(0, -1);
                    moved = false;
                }

                timeBar.fillAmount = 0; //barra vacia
                held = false;
                imagen.SetActive(false);
            }
        }
    }
}
