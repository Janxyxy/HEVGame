using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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

    private Vector3 direction;
    private Rigidbody rb;

    bool drive = false;

    // Start is called before the first frame update
    void Start()
    {
      
        canvas2.gameObject.SetActive(true);
        canvas.gameObject.SetActive(true);
        particle.enableEmission = false;
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.forward;
        direction = Vector3.forward;
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
            transform.position = new Vector3(0, 0, 0);  

        }

    }

    public void Drive()
    {
        drive = true;
        canvas2.gameObject.SetActive(false);
        particle.enableEmission = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Prekazka"))
        {
            
            Debug.Log("Kolize s prekaou");

        }
    }
}
