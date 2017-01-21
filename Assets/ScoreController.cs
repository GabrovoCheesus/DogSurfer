using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public GameObject Dog;
    private PlayerController playerController;
    private ulong count = 0;

    // Use this for initialization
    void Start()
    {
        count = 0;
        playerController = Dog.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isAlive)
        {
            if (count % 10 == 0)
            {
                var text = GetComponent<Text>();
                int score = int.Parse(text.text) + 1;

                text.text = score.ToString();
            }

            count += 1;
        }
    }
}
