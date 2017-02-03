using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private bool canMove = true;

    public bool isAlive = true;
    public bool hasWon = false;

    public ParticleSystem dust;

    public GameObject surf;

    public float thrust;
    public Rigidbody2D rb;

    public float forwardThrust = 1;


    public float a = 1;
    public float b = 1;

    public float currentMaxVelocity = 5;
    public float minVelocity = 2;
    public float winVelocity = 1;

    public float drownDuration = 2.0f;
    public float finishDuration = 1.0f;

    public float speed = 100;

    public GameObject player;

    public bool CanJump { get; internal set; }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dust.Stop();
    }

    public void Update()
    {
        if (!canMove)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanJump)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

                rb.AddForce(transform.up * thrust);
            }
        }

        rb.AddForce(new Vector2(a, b) * forwardThrust * Time.deltaTime * speed);
        var vel = rb.velocity.normalized;

        rb.velocity = vel * currentMaxVelocity;

        if(rb.velocity == new Vector2(0,0))
            rb.velocity = vel * 4 * currentMaxVelocity;
    }

    internal void PlayDethScene()
    {
        StartCoroutine(DethCoroutine());
    }

    private IEnumerator DethCoroutine()
    {
        dust.Play();
        currentMaxVelocity = minVelocity;

        yield return new WaitForSeconds((int)drownDuration);

        Destroy(player);
        isAlive = false;
    }

    private IEnumerator WinCoroutine()
    {
        currentMaxVelocity = winVelocity;
        ThrowSurf();

        yield return new WaitForSeconds((int)finishDuration);
        
        hasWon = true;
     }

    internal void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    public void ThrowSurf()
    {
        canMove = false;

        surf.transform.parent = null;

        surf.AddComponent<Rigidbody2D>();

        var rb = surf.GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * 100);
    }
}
