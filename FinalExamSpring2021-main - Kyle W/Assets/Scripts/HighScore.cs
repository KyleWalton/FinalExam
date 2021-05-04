using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static string path = "./highscores.txt";
    public Text HighscoresList;

    public class scoreList
    {
        public int Score { get; set; }
        public string Name { get; set; }

        public scoreList()
        {
        }

        public scoreList(int Score, string Name)
        {
            this.Name = Name;
            this.Score = Score;
        }
    };

    public ArrayList HighscoresText = new ArrayList();

    public scoreList[] scores = new scoreList[11];

    public void Start()
    {
        
        for (int i = 0; i < scores.Length; i++)
        {
            Debug.Log(scores.Length);
            scores[i] = new scoreList();
            scores[i].Name = "temp";
            scores[i].Score = 0;
        }
        newScore();
        readScores();
        WriteScore();
        displayScores();
    }

    public void newScore()
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(("" + Data.Instance.score + " " + Data.Instance.playerName));
        writer.Close();
    }

    public void WriteScore()
    {
        File.WriteAllText(path, string.Empty);
        StreamWriter writer = new StreamWriter(path);
        for (int i = 0; i < scores.Length-1; i++)
        {
            writer.WriteLine(scores[i].Score + " " + scores[i].Name);
        }
        writer.Close();
    }

    public void readScores()
    {
        StreamReader reader = new StreamReader(path);

        for (int i = 0; i < 11; i++)
        {
            if (reader.Peek() != -1)
            {
                HighscoresText.Add(reader.ReadLine());
            }
        }

        //for (int i = 0; i < HighscoresText.Capacity-1;i++)
        //{
        //    Debug.Log(HighscoresText[i] + "\n");
        //}
        Debug.Log("Scores have been read, output above. Sorting.\n");
        reader.Close();
        sort(HighscoresText);
    }

    public void displayScores()
    {
        for (int i = 0; i < 10; i++)
        {
            HighscoresList.text += (i + 1) + ". " + scores[i].Score + " " + scores[i].Name + "\n";
        }
    }

    public void sort(ArrayList arr)
    {
        int space;
        string name;
        int score;
        string temp;

        for (int i = 0; i < arr.Count; i++)
        {
            temp = "" + arr[i];
            space = temp.IndexOf(" ");
            score = Int32.Parse(temp.Substring(0, space));
            name = temp.Substring(space + 1, Math.Abs((space + 1) - temp.Length));

            scores[i].Score = score;
            scores[i].Name = name;
        }
        scores = bubbleSort(scores);
    }

    static scoreList[] bubbleSort(scoreList[] scores)
    {
        int n = 11;
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - i - 1; j++)
                if (scores[j + 1].Name != "")
                {
                    if (scores[j].Score < scores[j + 1].Score)
                    {
                        // swap temp and arr[i]
                        scoreList temp = scores[j];
                        scores[j] = scores[j + 1];
                        scores[j + 1] = temp;
                    }
                }

        return scores;
    }

    public void clearHighScores()
    {
        HighscoresText.Clear();
        HighscoresList.text = "HighScores\n";
        File.WriteAllText(path, string.Empty);
    }
}