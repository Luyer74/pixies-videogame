using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ManageObjective : MonoBehaviour
{
    //Estos arreglos tienen los ingredientes que son necesarios para hacer los platos
    private int[] plato1 = new int[3];
    private int[] plato2 = new int[3];
    private int[] plato3 = new int[3];

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    public GameObject Timer;

    public Sprite mushroom;
    public Sprite tomato;
    public Sprite onion;

    public Sprite mushroomDish;
    public Sprite tomatoDish;
    public Sprite onionDish;

    //Cada casilla es un sprite de ingrediente, la cuarta casilla es el sprite del plato
    public Image[] img_plato1 = new Image[4];
    public Image[] img_plato2 = new Image[4];
    public Image[] img_plato3 = new Image[4];

    // Start is called before the first frame update
    void Start()
    {
        setObjective(1);
        setObjective(2);
        setObjective(3);
    }

    //La funcion asigna las ingredientes para preparas el plato específico (1, 2 o 3)
    public void setObjective(int plato)
    {
    	int ing = UnityEngine.Random.Range(0, 3);
        if (plato == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                plato1[i] = ing;
                
                img_plato1[i].GetComponent<Image>().sprite = setIngridient(plato1[i]);
            }

            img_plato1[3].GetComponent<Image>().sprite = setDish(plato1);

        }else if (plato == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                plato2[i] = ing;
                
                img_plato2[i].GetComponent<Image>().sprite = setIngridient(plato2[i]);
            }

            img_plato2[3].GetComponent<Image>().sprite = setDish(plato2);

        }else
        {
            for (int i = 0; i < 3; i++)
            {
                plato3[i] = ing;

                img_plato3[i].GetComponent<Image>().sprite = setIngridient(plato3[i]);
            }

            img_plato3[3].GetComponent<Image>().sprite = setDish(plato3);
        }
    }

    //Esta funcion asigna el sprite correspondiente a la interfaz
    private Sprite setIngridient(int ing)
    {
        if(ing == 0)
        {
            return mushroom;
        } else if (ing == 1)
        {
            return tomato;
        }else if (ing == 2)
        {
            return onion;
        }

        return null;
    }

    //Esta función asigna el sprite de platillo en base a su mayoría de ingredientes
    private Sprite setDish(int[] ing)
    {
        int a = 0;
        int b = 0;
        int c = 0;

        for (int i=0; i < ing.Length; i++)
        {
            if (ing[i] == 0) a++;
            if (ing[i] == 1) b++;
            if (ing[i] == 2) c++;
        }

        if (a > b && a > c )
        {
            return mushroomDish;
        }else if (b > a && b > c)
        {
            return tomatoDish;
        }else
        {
            return onionDish;
        }
    }

    //Aquie se revisa que el platillo ingresado concuerde con alguno de los objetivos
    public bool checkDish(int[] done)
    {
        if(done.SequenceEqual(plato1))
        {   
            obj1.SetActive(false);
            Timer.GetComponent<GameTimer>().increaseTimer(20); //Si el plato es correcto se aumenta el tiempo
            StartCoroutine(newDish(1, obj1));
            return true;
        }else if (done.SequenceEqual(plato2))
        {
            obj2.SetActive(false);
            Timer.GetComponent<GameTimer>().increaseTimer(20);
            StartCoroutine(newDish(2, obj2));
            return true;
        }else if (done.SequenceEqual(plato3))
        {
            obj3.SetActive(false);
            Timer.GetComponent<GameTimer>().increaseTimer(20);
            StartCoroutine(newDish(3, obj3));
            return true;
        }
        else
        {
            Timer.GetComponent<GameTimer>().increaseTimer(-20); //Si el plato es incorrecto disminuye el tiempo
            return false;
        }
    }

    //Esta función genera un nuevo plato (objetivo) despues de 5 segundos de terminado el anterior
    IEnumerator newDish(int x, GameObject obj)
    {
        yield return new WaitForSeconds(5);
        setObjective(x);
        obj.SetActive(true);
    }
}
