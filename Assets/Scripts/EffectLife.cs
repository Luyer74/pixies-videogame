using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLife : MonoBehaviour
{
    public float tiempoEfecto;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tiempoEfecto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
