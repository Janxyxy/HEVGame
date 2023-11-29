using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawnPrekazky : MonoBehaviour
{
    [SerializeField]
    private GameObject Prekazka;

    Camera camera;
    List<GameObject> prekazky;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        prekazky = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("This is a message to the console.");
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                GameObject newPrekazka = Instantiate(Prekazka, new Vector3(hit.point.x - 0.35f, hit.point.y, hit.point.z - 0.35f), Quaternion.identity);
                prekazky.Add(newPrekazka); 
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            foreach (GameObject prekazkaObject in prekazky)
            {
                DestroyImmediate(prekazkaObject, true);
            }
            prekazky.Clear();

        }
    }
}