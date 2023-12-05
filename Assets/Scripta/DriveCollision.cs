using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    [SerializeField]
    private GameObject skillissue;

    private Vector3 direction;
    private Rigidbody rb;

    public float rotationSpeed = 50f;
    private bool drive = false;
    public int levl;
    private int kanystr;
    private bool spin;
    private bool isIncreasing = true;

    //border
    private float minX = -11f;
    private float maxX = 11f;
    private float minZ = -5.25f;
    private float maxZ = 5.25f;

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
        skillissue.SetActive(false);

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
            StartCoroutine(SkillIssueCoroutine());
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

        gamemanagment.VroomPlay();

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

        gamemanagment.ChangeLevel(levl);
        spawnObstacles.ZnicKanystr();
        spawnObstacles.DeletePreviosObs();
        spawnObstacles.SpawnObs(levl);
        gamemanagment.NulaKanistru();
        gamemanagment.VrooStop();



    }

    private IEnumerator SkillIssueCoroutine()
    {
        skillissue.SetActive(true);
        yield return new WaitForSeconds(2);
        skillissue.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cil"))
        {
            Debug.Log("Kolize s cílem");
            if (kanystr >= 1) {
                levl++;
                NoDrive();

            }
            else
            {
                NoDrive();
                StartCoroutine(SkillIssueCoroutine());

            }
          
        }

        if (collision.gameObject.CompareTag("Zabiji"))
        {
            NoDrive();
            StartCoroutine(SkillIssueCoroutine());


        }

        if (collision.gameObject.CompareTag("Kanystr"))
        {
            kanystr++;
            spawnObstacles.ZnicKanystr();
            gamemanagment.VsechnyKanistry();
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


