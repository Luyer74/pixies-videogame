using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getTomato : MonoBehaviour
{
    public GameObject tom;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tom.SetActive(true);
            Debug.Log("Tomato created");
        }
    }
}
