﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isAlive = true;

    public ParticleSystem dust;

    public float thrust;
    public Rigidbody2D rb;

    public float forwardThrust = 1;
    public float a = 1;
    public float b = 1;

    public float currentMaxVelocity = 5;
    public float minVelocity = 2;

    public float drownDuration = 2.0f;

    public float speed = 100;

    public GameObject player;

    public bool CanJump { get; internal set; }

    // Use this for initialization
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dust.Stop();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump)
            {
                print("space key was pressed");
                if (rb == null)
                    print("no ewrw");

                rb.AddForce(transform.up * thrust);
            }
        }

        rb.AddForce(new Vector2(a, b) * forwardThrust * Time.deltaTime * speed);
        var vel = rb.velocity.normalized;

        rb.velocity = vel * currentMaxVelocity ;
    }

    internal void PlayDethScene()
    {
        dust.Play();
        currentMaxVelocity = minVelocity;

        Destroy(player, drownDuration);

        isAlive = false;
    }
}
