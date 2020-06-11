﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    SpriteRenderer spr;
    public Sprite sliced1;
    public Sprite sliced2;
    public Sprite sliced3;
    public Sprite TomatoSoup;
    public Sprite OnionSoup;
    public Sprite MushroomSoup;
    public Sprite badSoup;
    public Sprite cleanPlateSprite;
    public GameObject SonidoAgarrar;
    public GameObject SonidoSoltar;
    public bool hasObject;
    public bool isSliced;
    public bool clean;
    public GameObject ingrediente1;
    public GameObject ingrediente2;
    public GameObject ingrediente3;
    public GameObject plato1;
    public GameObject plato2;
    public static GameObject ingrediente;
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
                
                ingrediente = Instantiate(ingrediente3, gameObject.transform);
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

    public void washPlate()
    {
        spr = ingrediente.GetComponentInChildren<SpriteRenderer>();
        if (ingrediente.name == "DirtyPlate(Clone)") spr.sprite = cleanPlateSprite;
        Debug.Log("washed");
        clean = true;
    }

    public void cook()
    {
        Instantiate(SonidoSoltar);
        Destroy(ingrediente);
        Debug.Log("cooked ingredient");
        hasObject = false;
    }

    public void getSoup(bool goodSoup, int tomatos, int onions, int mushrooms)
    {
        spr = ingrediente.GetComponentInChildren<SpriteRenderer>();
        if (!goodSoup) spr.sprite = badSoup;
        else if (tomatos == 3) spr.sprite = TomatoSoup;
        else if (onions == 3) spr.sprite = OnionSoup;
        else if (mushrooms == 3) spr.sprite = MushroomSoup;

    }

    public void getPlate(GameObject obj)
    {
        if (!obj.GetComponent<getPlate>().used)
        {
            Instantiate(SonidoAgarrar);
            Debug.Log("got plate");
            hasObject = true;
            isSliced = false;
            clean = true;
            ingrediente = Instantiate(plato1, gameObject.transform);
            ingrediente.SetActive(true);
        }
        else
        {
            Instantiate(SonidoAgarrar);
            Debug.Log("got dirty");
            hasObject = true;
            isSliced = false;
            clean = false;
            ingrediente = Instantiate(plato2, gameObject.transform);
            ingrediente.SetActive(true);
        }
    }
}