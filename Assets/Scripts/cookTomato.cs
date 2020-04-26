using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookTomato : MonoBehaviour
{
    public GameObject tom;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tom.SetActive(false);
            Debug.Log("Tomato in pot");
        }
    }
}
