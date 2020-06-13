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
    private int[] plato = new int[3];
    Score score;
    ManageObjective objective;
    public GameObject goodPlateSound;
    public GameObject badPlateSound;

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

    void Start()
    {
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;
        objective = GameObject.FindObjectOfType(typeof(ManageObjective)) as ManageObjective;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(intkey) && ingrediente && player1.isCooked == true)
        {
            player1.finish();
            plato = player1.GetSoupIngredients();
            if(objective.checkDish(plato))
            {
                Instantiate(goodPlateSound);
                score.AddScore();
            }
            else
            {
                Instantiate(badPlateSound);
                score.SubtractScore();
            }
        }
    }
}
