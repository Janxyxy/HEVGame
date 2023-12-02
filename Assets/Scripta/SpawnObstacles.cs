using System.Collections;
using System.Collections.Generic;
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
        new Vector3(0, 0.5f, 2), //levl 0
        new Vector3(0, 0.5f, 4), //levl 1...
        new Vector3(5, 0.5f, 6)
    };

    private Vector3[] prekazkalevl_0 = new Vector3[] //levl 0 prekazky
    {
         new Vector3(2, 0.5f, 2), // prvni prekazka v levlu 1
    };

    private Vector3[] prekazkalevl_1 = new Vector3[] //levl 1 prekazky
    {
         new Vector3(3, 0.5f, 3),
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
