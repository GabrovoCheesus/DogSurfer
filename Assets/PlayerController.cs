﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D rb;
    public float forwardThrust = 1;

    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("space key was pressed");
            if (rb == null)
                print("no ewrw");

            rb.AddForce(transform.up * thrust);
        }

        rb.AddForce(new Vector2(forwardThrust, 1) * forwardThrust);
    }
}
