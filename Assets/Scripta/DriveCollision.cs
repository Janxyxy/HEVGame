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
            NoDrive();
        }

    }

    public void Drive()
    {
        drive = true;
        canvas2.gameObject.SetActive(false);
        particle.enableEmission = true;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 1.0f * Time.deltaTime);

    }

    public void NoDrive()
    {
        direction = Vector3.forward;
        rb.velocity = direction * 0;
        drive = false;
        transform.position = new Vector3(0, 0, 0); 
        canvas2.gameObject.SetActive(true);
        particle.enableEmission = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        
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
