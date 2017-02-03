using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTextController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var username = PlayerPrefs.GetString("Username");
        var score = PlayerPrefs.GetString("Score");
        bool isWon = bool.Parse(PlayerPrefs.GetString("IsWon"));

        var text = GetComponent<Text>();
        StringBuilder sb = new StringBuilder();

        if(isWon)
        {
            sb.AppendLine("You won!");
        }
        else
        {
            sb.AppendLine("You lost!");
        }

        sb.AppendLine(username);
        sb.AppendLine("Score:" + score);

        text.text = sb.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
