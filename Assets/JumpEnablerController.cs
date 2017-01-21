using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnablerController : MonoBehaviour
{
    public GameObject player;

    private PlayerController playerController;

    public void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    public void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerController.CanJump = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerController.CanJump = false;
    }


}
