using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DriveCollision : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform auto;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private SpawnObstacles spawnObstacles;
    [SerializeField]
    private SpawnPrekazky spawnPrekazky;
    [SerializeField]
    private GameManagment gamemanagment;

    private Vector3 direction;
    private Rigidbody rb;

    public float rotationSpeed = 50f;
    private bool drive = false;
    public int levl;
    private int kanystr;
    private bool spin;
    private bool isIncreasing = true;

    //border
    private float minX = -9.5f;
    private float maxX = 9.5f;
    private float minZ = -4.85f;
    private float maxZ = 4.85f;

    // Start is called before the first frame update


    public void Setup()
    {
        gamemanagment.HideLoading();
        levl = 0;
        kanystr = 0;
        spin = true;
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.forward;
        direction = Vector3.forward;
        spawnObstacles.DeletePreviosObs();
        spawnObstacles.SpawnObs(levl);

        var emission = particle.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (drive)
        {

            rb.velocity = direction * speed * Time.deltaTime;
        }

        if (auto.position.x < minX || auto.position.x > maxX || auto.position.z < minZ || auto.position.z > maxZ) //border check
        {
            Debug.Log("Out of border");
            NoDrive();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            NoDrive();
        }

        if (spin)
        {
            if (rotationSpeed >= 75f || rotationSpeed <= -75f)
            {
                isIncreasing = !isIncreasing;
            }
            rotationSpeed += isIncreasing ? 1f : -1f;
        }

        if (spin)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

    }

    public void Drive()
    {
        drive = true;
        //spin = false;
        gamemanagment.Hideplay();
        var emission = particle.emission;
        emission.enabled = true;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    public void NoDrive()
    {
        drive = false;
        kanystr = 0;
        spin = true;
        gamemanagment.Showplay();
        direction = Vector3.forward;
        rb.velocity = direction * 0;
        spawnPrekazky.Reset();
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        var emission = particle.emission;
        emission.enabled = false;

        spawnObstacles.ZnicKanystr();
        spawnObstacles.DeletePreviosObs();
        spawnObstacles.SpawnObs(levl);
    

    }

 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cil"))
        {
            Debug.Log("Kolize s cílem");
            if (kanystr == 1) {
                levl++;
                kanystr = 0;
                gamemanagment.ChangeLevel(levl);
                NoDrive();
                spawnObstacles.DeletePreviosObs();
                spawnObstacles.SpawnObs(levl);
            }
            else
            {
                NoDrive();
            }
          
        }

        if (collision.gameObject.CompareTag("Zabiji"))
        {
            NoDrive();
        }

        if (collision.gameObject.CompareTag("Kanystr"))
        {
            kanystr++;
            spawnObstacles.ZnicKanystr();
            Debug.Log("Kolize s kanystrem");
        }

        if (collision.gameObject.CompareTag("Prekazka"))
        {
            Debug.Log("Kolize s prekaou");
            
            transform.Rotate(0, 90, 0); 

            if (direction == Vector3.forward)
            {
                direction = Vector3.right;
            }
            else if (direction == Vector3.right)
            {
                direction = Vector3.back;
            }
            else if (direction == Vector3.back)
            {
                direction = Vector3.left;
            }
            else if (direction == Vector3.left)
            {
                direction = Vector3.forward;
            }

        }
    }

}


