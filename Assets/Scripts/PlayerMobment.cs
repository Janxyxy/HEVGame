using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobment : MonoBehaviour
{
    //Movment script

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float speed;

    private Vector3 direction;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.forward;
    }


    void Update()
    {
        direction = Vector3.forward;
        rb.velocity = direction * speed * Time.deltaTime;

    }
}
