using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public InputField inputField;

	// Use this for initialization
	void Start () {
 //       DontDestroyOnLoad(gameObject);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        string name = inputField.text.Trim();

        if (string.IsNullOrEmpty(name))
            name = "Unknown";

        PlayerPrefs.SetString("Username", name);
        SceneManager.LoadScene("MainScene");
    }

    public void OnBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnEnd()
    {
        Application.Quit();
    }
}
