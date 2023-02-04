using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 20.0f;
    [SerializeField] private float fallspeed = -10.0f;
    private float dirX;

    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.acceleration.x * movespeed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX,fallspeed*Time.deltaTime);

    }
}
