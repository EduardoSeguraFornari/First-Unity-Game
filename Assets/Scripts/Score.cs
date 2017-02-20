using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreAtualText;
    public Text topScoreText;
    public static int score;
    public static int topScore;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            topScore = PlayerPrefs.GetInt("Score");
        }
        else
        {
            PlayerPrefs.SetInt("Score", 0);
        }

        topScoreText.text = "Top " + topScore;

        int y = Screen.height;
        int x = Screen.width;
        int diferencaY = y / 20;

        int fontSize = x / 20;

        scoreAtualText.fontSize = fontSize;
        scoreAtualText.GetComponent<RectTransform>().position = new Vector3(100, y - ((y / 10) * 2) + diferencaY);

        topScoreText.fontSize = fontSize;
        topScoreText.GetComponent<RectTransform>().position = new Vector3(100, y - ((y / 10) * 3) + diferencaY);
    }

    // Update is called once per frame
    void Update()
    {
        scoreAtualText.text = score.ToString();
        if (score >= topScore)
        {
            topScoreText.text = "Top " + topScore;
            topScore = score;
            SaveScore();
        }
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
}
