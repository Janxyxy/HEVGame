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

    private Vector3[] pozicecile = new Vector3[]
    {
        new Vector3(0, 0.5f, 2), //levl 0
        new Vector3(0, 0.5f, 4), //levl 1...
        new Vector3(5, 0.5f, 6)
    };



    public void SpawnObs(int levl)
    {
        if(levl < pozicecile.Length)
        {
            lastcilobstacles = Instantiate(Cil, pozicecile[levl], Quaternion.Euler(0, 180, 0));
        }
       
        
    }
    public void DeletePreviosObs()
    {
        if(lastcilobstacles != null)
        {
            Destroy(lastcilobstacles);
        }

    }
}
