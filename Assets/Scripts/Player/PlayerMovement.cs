using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float rotateSpeed = 10f;


    private PlayerController controller;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        controller = gameObject.GetComponent<PlayerController>();
    }
 

    private void FixedUpdate() {
        float moving = controller.Moving * speed;
        float rotation = controller.Rotation * rotateSpeed;

        rb.AddForce((Vector2)transform.up * moving);
        rb.AddTorque(-rotation);
    }
}