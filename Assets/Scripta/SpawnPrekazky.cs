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
    private bool muzespawnovat;

    // Start is called before the first frame update
    void Start()
    {
        muzespawnovat = true;
        camera = GetComponent<Camera>();
        prekazky = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && muzespawnovat)
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
            SmazaniPrekazek();
            muzespawnovat = true;

        }
    }

    private void SmazaniPrekazek()
    {
        foreach (GameObject prekazkaObject in prekazky)
        {
            DestroyImmediate(prekazkaObject, true);
        }
        prekazky.Clear();
    }

    public void Hra()
    {
        muzespawnovat = false;
    }
}