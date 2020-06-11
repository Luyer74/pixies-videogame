using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    SpriteRenderer spr;
    public Sprite sliced1;
    public Sprite sliced2;
    public Sprite sliced3;
    public GameObject SonidoAgarrar;
    public GameObject SonidoSoltar;
    public bool hasObject;
    public bool isSliced;
    public string objectType;
    public GameObject ingrediente1;
    public GameObject ingrediente2;
    public GameObject ingrediente3;
    public GameObject plato1;
    public static GameObject ingrediente;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public ParticleSystem fire3;
    Score score;

    void Start()
    {
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;
    }

    public void getIngredient(GameObject obj)
    {
        if (!hasObject)
        {
            if (obj.name == "tomatoBox")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got tomato");
                hasObject = true;
                isSliced = false;
                objectType = "ingredient";
                ingrediente = Instantiate(ingrediente1, gameObject.transform);
                ingrediente.SetActive(true);
                score.AddScore();
            }
            else if (obj.name == "Onion Box")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got onion");
                hasObject = true;
                isSliced = false;
                objectType = "ingredient";
                ingrediente = Instantiate(ingrediente2, gameObject.transform);
                ingrediente.SetActive(true);
                score.SubtractScore();
            }
            else if (obj.name == "Mushroom Box")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got mushroom");
                hasObject = true;
                isSliced = false;
                objectType = "ingredient";
                ingrediente = Instantiate(ingrediente3, gameObject.transform);
                ingrediente.SetActive(true);
            }
            else if (obj.name == "plateGiver")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got plate");
                hasObject = true;
                isSliced = false;
                objectType = "plate";
                ingrediente = Instantiate(plato1, gameObject.transform);
                ingrediente.SetActive(true);
            }
        } 
    }

    public void useIngredient(GameObject obj) 
    {
        Instantiate(SonidoSoltar);
        if (obj.CompareTag("CutStation"))
        {
            //cambiar sprite a sprite cortado
            spr = ingrediente.GetComponentInChildren<SpriteRenderer>();
            if (ingrediente.name == "Tomato(Clone)") spr.sprite = sliced1;
            else if (ingrediente.name == "Onion(Clone)") spr.sprite = sliced2;
            else if (ingrediente.name == "Mushroom(Clone)") spr.sprite = sliced3;
            Debug.Log("cut ingredient");
            isSliced = true;
        }
    }

    public void cook(GameObject obj)
    {
        if (obj.CompareTag("CookPot"))
        {
            Instantiate(SonidoSoltar);
            Destroy(ingrediente);
            Debug.Log("cooked ingredient");
            hasObject = false;
        }
    }
}