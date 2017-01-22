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
        if (playerController == null)
            return;

        playerController.CanJump = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerController = other.GetComponent<PlayerController>();
        if (playerController == null)
            return;

        playerController.CanJump = false;
    }


}
