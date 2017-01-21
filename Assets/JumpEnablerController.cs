using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnablerController : MonoBehaviour
{
    private PlayerController playerController;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerController = other.GetComponent<PlayerController>();
        playerController.CanJump = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerController = other.GetComponent<PlayerController>();
        playerController.CanJump = false;
    }


}
