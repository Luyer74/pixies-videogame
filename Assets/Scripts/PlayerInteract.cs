using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject SonidoAgarrar;
    public GameObject SonidoSoltar;
    public bool hasObject;
    public GameObject ingrediente1;
    public GameObject ingrediente2;
    public GameObject ingrediente3;
    public static GameObject ingrediente;
   
    public void getIngredient(GameObject obj)
    {
        if (!hasObject)
        {
            Instantiate(SonidoAgarrar);
            if (obj.name == "tomatoBox")
            {
                Debug.Log("got tomato");
                hasObject = true;
                ingrediente = Instantiate(ingrediente1, gameObject.transform);
                ingrediente.SetActive(true);
  
            }
            else if (obj.name == "Onion Box")
            {
                Debug.Log("got onion");
                hasObject = true;
                ingrediente = Instantiate(ingrediente2, gameObject.transform);
                ingrediente.SetActive(true);
            }
            else if (obj.name == "Mushroom Box")
            {
                Debug.Log("got mushroom");
                hasObject = true;
                ingrediente = Instantiate(ingrediente3, gameObject.transform);
                ingrediente.SetActive(true);
            }
        }
        else
        {
            Instantiate(SonidoSoltar);
            if (obj.CompareTag("CookPot"))
            {
                Destroy(ingrediente);
                Debug.Log("cooked ingredient");
                hasObject = false;
            }
            else if (obj.CompareTag("CutStation"))
            {
                Destroy(ingrediente);
                Debug.Log("cut ingredient");
                hasObject = false;
            }
            else if (obj.CompareTag("Trash"))
            {
                Destroy(ingrediente);
                Debug.Log("tirado a la basura");
                hasObject = false;
            }
        }

    }


}
