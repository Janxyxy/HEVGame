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
    private float backDistance = 1.0f; // Adjust this value based on how much you want the car to move back.
    private float turnAngle = 90.0f; // Adjust this value based on how much you want the car to turn.

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
            Debug.Log("Collision with obstacle");

            // Move back and turn
            Vector3 backVector = -collision.contacts[0].normal * backDistance;
            transform.position += backVector;

            // Rotate by 90 degrees around the up axis
            transform.Rotate(Vector3.up, turnAngle);

            // You can also add any other logic here, e.g., decrease health, play a sound, etc.
        }
    }
}
