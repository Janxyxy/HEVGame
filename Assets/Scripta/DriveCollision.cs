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
    private AudioSource nightcall;
    [SerializeField]
    private SpawnObstacles spawnObstacles;
    [SerializeField]
    private SpawnPrekazky spawnPrekazky;


    private Vector3 direction;
    private Rigidbody rb;

    bool drive = false;
    int levl;


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
     


        if (Input.GetKeyDown(KeyCode.R))
        {       
            NoDrive();
            spawnObstacles.DeletePreviosObs();
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
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 1.0f * Time.deltaTime);

    }

    public void NoDrive()
    {
        direction = Vector3.forward;
        rb.velocity = direction * 0;
        drive = false;
        spawnPrekazky.Reset();
        transform.position = new Vector3(0, 0, 0); 
        canvas2.gameObject.SetActive(true);
        var emission = particle.emission;
        emission.enabled = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cíl")) {
            levl++;
            NoDrive();
            spawnObstacles.DeletePreviosObs();
            spawnObstacles.SpawnObs(levl);

        }
        
        if (collision.gameObject.CompareTag("Prekazka"))
        {
            
            Debug.Log("Kolize s prekaou");
            transform.Rotate(0, 90, 0); //Otoèení 90
            


            if (direction == Vector3.forward)
            {
                direction = Vector3.right;
            }else if (direction == Vector3.right)
            {
                direction = Vector3.back;
            }else if (direction == Vector3.back)
            {
                direction = Vector3.left;
            }else if (direction == Vector3.left)
            {
                direction = Vector3.forward;
            }

        }
    }
}
