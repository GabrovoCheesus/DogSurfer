using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        print("finished");

        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller == null)
            return;

        controller.Win();
    }
}
