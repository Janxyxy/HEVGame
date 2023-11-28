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

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
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
                Instantiate(Prekazka, new Vector3(hit.point.x - (float)0.35, hit.point.y,hit.point.z - (float)0.35), Quaternion.identity);
            }
        }
    }
}