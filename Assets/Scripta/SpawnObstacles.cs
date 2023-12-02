using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField]
    private GameObject Cil;
    [SerializeField]
    private GameObject Prekazka_zabiji;

    GameObject lastcilobstacles;
    List<GameObject> previosprekazky = new List<GameObject>();

    private Vector3[] pozicecile = new Vector3[]
    {
        new Vector3(4.5f, 0.5f, -3f), //levl 0
        new Vector3(0, 0.5f, 4), //levl 1...
        new Vector3(5.4f, 0.5f, 3.4f), // levl 2 
        new Vector3(-7.9f, 0.5f, -1.3f), // levl 3 
        new Vector3(3.3f, 0.5f, -4.6f), // levl 4
        new Vector3(-4.6f, 0.5f, -4.4f) // levl 5
    };

    private Vector3[] prekazkalevl_0 = new Vector3[] //levl 0 prekazky
    {
         new Vector3(6f, 0.5f, 2.5f), // prvni prekazka v levlu 0
         new Vector3(0f, 0.5f, 4f), // druha prekazka v levlu 0
    };

    private Vector3[] prekazkalevl_1 = new Vector3[] //levl 1 prekazky
    {
         new Vector3(3, 0.5f, 3),
    };

    private Vector3[] prekazkalevl_2 = new Vector3[] // levl 2 prekazky
    {
        new Vector3 (2.6f, 0.5f, 1.9f), // prvni prekazka 
        new Vector3 (7.3f, 0.5f, 0.1f), // druha prekazka 
        new Vector3 (8, 0.5f, 5), // treti prekazka 
        new Vector3 (3.7f, 0.5f, 5.8f) // ctvrta prekazka
    };

    private Vector3[] prekazkalevl_3 = new Vector3[] // levl 3 prekazky
    {
        new Vector3(-9.3f, 0.5f, 4),
        new Vector3(-8.7f, 0.5f, 0.09f),
        new Vector3(-6, 0.5f, -2.9f),
        new Vector3(-4.9f, 0.5f, 0.8f),
        new Vector3(-3.5f, 0.5f, 3.6f),
        new Vector3(-0.2f, 0.5f, -2.8f),
        new Vector3(3.2f, 0.5f, 5.4f),
        new Vector3(2.4f, 0.5f, -2.4f),
        new Vector3(6.4f, 0.5f, 3.41f)
    };

    private Vector3[] prekazkalevl_4 = new Vector3[] // levl 4 prekazky 
    {
        new Vector3(-7.2f, 0.5f, -5.5f),
        new Vector3(-3.7f, 0.5f, -6.3f),
        new Vector3(-2.6f, 0.5f, -4.2f),
        new Vector3(1.3f, 0.5f, -5.2f),
        new Vector3(5.4f, 0.5f, 4.7f),
        new Vector3(8.1f, 0.5f, -1.7f),
        new Vector3(3.6f, 0.5f, -1.7f),
        new Vector3(6.7f, 0.5f, 3.4f),
        new Vector3(1.3f, 0.5f, 2.5f),
        new Vector3(-2.3f, 0.5f, 4.9f),
        new Vector3(-2.6f, 0.5f, 1.8f),
        new Vector3(-7.34f, 0.5f, 5.4f)
    };

    private Vector3[] prekazkalevl_5 = new Vector3[] // levl 5 prekazky
    {
        new Vector3(-5.4f, 0.5f, -3.1f),
        new Vector3(-3.7f, 0.5f, -3.1f),
        new Vector3(-5.72f, 0.5f, -4.4f),
        new Vector3(-5.72f, 0.5f, -5.7f),
        new Vector3(-4.6f, 0.5f, -5.7f),
        new Vector3(-3.72f, 0.5f, -4.4f),
        new Vector3(-3.72f, 0.5f, -5.4f)
    };

    Vector3[] VybranePrekazky = new Vector3[0]; 

    public void SpawnObs(int levl)
    {
        if (levl < pozicecile.Length)
        {
            lastcilobstacles = Instantiate(Cil, pozicecile[levl], Quaternion.Euler(0, 180, 0));
        }


        if (levl == 0)
        {
            VybranePrekazky = prekazkalevl_0;
        }
        else if (levl == 1)
        {
            VybranePrekazky = prekazkalevl_1;
        }
        else if (levl == 2)
        {
            VybranePrekazky = prekazkalevl_2;
        } 
        else if (levl == 3)
        {
            VybranePrekazky = prekazkalevl_3;
        }
        else if (levl == 4)
        {
            VybranePrekazky = prekazkalevl_4;
        }
        else if(levl == 5)
        {
            VybranePrekazky = prekazkalevl_5;
        }
        foreach (Vector3 pozice in VybranePrekazky)
        {
            GameObject obstacle = Instantiate(Prekazka_zabiji, pozice, Quaternion.identity);
            previosprekazky.Add(obstacle);
        }

    }
    public void DeletePreviosObs()
    {
        if (lastcilobstacles != null)
        {
            Destroy(lastcilobstacles);
        }

        foreach (GameObject prekazka in previosprekazky)
        {
            Destroy(prekazka);
        }

    }
}
