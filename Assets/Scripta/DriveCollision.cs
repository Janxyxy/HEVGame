using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveCollision : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform auto;
    [SerializeField]
    private Canvas canvas;

    private Vector3 direction;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        canvas.gameObject.SetActive(true);
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.forward;
        direction = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(0, 1, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Prekazka"))
        {
            
            Debug.Log("o holero, chito freddy fazbear");

            
            Destroy(collision.gameObject);
        }
    }
}
