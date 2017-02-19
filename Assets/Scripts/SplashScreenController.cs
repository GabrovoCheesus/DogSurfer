using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
    public string MainMenuSceneName = "Menu";

    public void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        SceneManager.LoadScene(MainMenuSceneName);
    }
}
