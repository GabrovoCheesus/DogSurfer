using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public GameObject Dog;
    private PlayerController playerController;
    private ulong count = 0;
    private string username;

    // Use this for initialization
    void Start()
    {
        count = 0;
        playerController = Dog.GetComponent<PlayerController>();
        username = PlayerPrefs.GetString("Username");
        print(username);
        setPoint(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isAlive)
        {
            if (count % 10 == 0)
            {
                var text = GetComponent<Text>();
                var currScore = GetScore(text.text);
                setPoint(currScore + 1);
            }

            count += 1;
        }
        else
        {
            var text = GetComponent<Text>();
            var currScore = GetScore(text.text);

            SaveHighScore(username, currScore);

            SceneManager.LoadScene("Menu");
        }
    }

    string GetUserName(string input)
    {
        return input.Substring(0, input.LastIndexOf(' '));
    }

    int GetScore(string input)
    {
        var index = input.LastIndexOf(" ");

        return int.Parse(input.Substring(index + 1, input.Length - (index + 1)));
    }

    void setPoint(int point)
    {
        var text = GetComponent<Text>();
        text.text = string.Format("{0} {1}", username, point);
    }

    void SaveHighScore(string personName, int score)
    {
        var persons = DeserializeHighScore();
        var person = new Person() { Name = personName, Score = score };
        persons.Add(person);

        persons.Sort((x, y) => y.Score.CompareTo(x.Score));

        SerializePersons(persons);
    }

    List<Person> DeserializeHighScore()
    {
        List<Person> persons = new List<Person>();

        var path = Path.Combine(Application.persistentDataPath, "highScore.db");

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            StreamReader reader = new StreamReader(fs);

            while (!reader.EndOfStream)
            {
                var person = Person.Deserialize(reader.ReadLine());

                persons.Add(person);
            }
        }

        return persons;
    }

    void SerializePersons(List<Person> persons)
    {
        var path = Path.Combine(Application.persistentDataPath, "highScore.db");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            StreamWriter writer = new StreamWriter(fs);
            writer.AutoFlush = true;

            foreach (var person in persons)
            {
                writer.WriteLine(string.Format("{0} {1}", person.Name, person.Score));
            }
        }
    }

    private class Person
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public static Person Deserialize(string input)
        {
            var person = new Person();

            person.Name = input.Substring(0, input.LastIndexOf(' '));

            var index = input.LastIndexOf(" ");
            person.Score = int.Parse(input.Substring(index + 1, input.Length - (index + 1)));

            return person;
        }
    }
}
