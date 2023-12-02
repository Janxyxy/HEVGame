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
    private Canvas canvas;
    [SerializeField]
    private Canvas canvas2;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private SpawnObstacles spawnObstacles;
    [SerializeField]
    private SpawnPrekazky spawnPrekazky;




    private Vector3 direction;
    private Rigidbody rb;

    bool drive = false;
    int levl;

    //border
    private float minX = -9.5f;
    private float maxX = 9.5f;
    private float minZ = -4.85f;
    private float maxZ = 4.85f;

    // Start is called before the first frame update
    void Start()
    {
        Setup();

    }

    private void Setup()
    {
        levl = 0;
        var emission = particle.emission;
        emission.enabled = false;
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.forward;
        direction = Vector3.forward;
        spawnObstacles.SpawnObs(levl);
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
            spawnObstacles.DeletePreviosObs();
            spawnObstacles.SpawnObs(levl);
        }

    }
    public void HideCanvas(Canvas canvas)
    {
        //Button1
        canvas.gameObject.SetActive(false);
    }

    public void Drive()
    {
        drive = true;
        canvas2.gameObject.SetActive(false);
        var emission = particle.emission;
        emission.enabled = true;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    public void NoDrive()
    {
        drive = false;
        direction = Vector3.forward;
        rb.velocity = direction * 0;
        spawnPrekazky.Reset();
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        canvas2.gameObject.SetActive(true); //playbutton

        var emission = particle.emission;
        emission.enabled = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cil"))
        {
            levl++;
            NoDrive();
            spawnObstacles.DeletePreviosObs();
            spawnObstacles.SpawnObs(levl);   
        }

        if (collision.gameObject.CompareTag("Zabiji"))
        {
            NoDrive();
        }

        if (collision.gameObject.CompareTag("Prekazka"))
        {

            Debug.Log("Kolize s prekaou");
            transform.Rotate(0, 90, 0); //Oto�en� 90



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


