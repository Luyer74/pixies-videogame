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
    public GameObject ingrediente1;
    public GameObject ingrediente2;
    public GameObject ingrediente3;
    public static GameObject ingrediente;
    public ParticleSystem fire1;
    public ParticleSystem fire2;
    public ParticleSystem fire3;

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
                ingrediente = Instantiate(ingrediente1, gameObject.transform);
                ingrediente.SetActive(true);

            }
            else if (obj.name == "Onion Box")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got onion");
                hasObject = true;
                isSliced = false;
                ingrediente = Instantiate(ingrediente2, gameObject.transform);
                ingrediente.SetActive(true);
            }
            else if (obj.name == "Mushroom Box")
            {
                Instantiate(SonidoAgarrar);
                Debug.Log("got mushroom");
                hasObject = true;
                isSliced = false;
                ingrediente = Instantiate(ingrediente3, gameObject.transform);
                ingrediente.SetActive(true);
            }
        }
        else
        {
            if (obj.CompareTag("CookPot"))
            {
                Instantiate(SonidoSoltar);
                if (obj.name == "cp1")
                {
                    fire1.Play();
                }
                else if (obj.name == "cp2")
                {
                    fire2.Play();
                }
                else if (obj.name == "cp3")
                {
                    fire3.Play();
                }
                Destroy(ingrediente);
                Debug.Log("cooked ingredient");
                hasObject = false;
            }
            else if (obj.CompareTag("Trash"))
            {
                Instantiate(SonidoSoltar);
                Destroy(ingrediente);
                Debug.Log("tirado a la basura");
                hasObject = false;
                isSliced = false;
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
}