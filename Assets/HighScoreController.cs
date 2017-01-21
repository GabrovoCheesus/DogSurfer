using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        var text = GetComponent<Text>();
        text.text += Environment.NewLine + LoadText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    string LoadText()
    {
        StringBuilder sb = new StringBuilder();
        var path = Path.Combine(Application.persistentDataPath, "highScore.db");

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            StreamReader reader = new StreamReader(fs);

            while (!reader.EndOfStream)
            {
                sb.AppendLine(reader.ReadLine());
            }
        }

        return sb.ToString();
    }
}
