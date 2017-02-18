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
        topScoreText.text = "Top " + topScore;
        int y = Screen.height;
        int x = Screen.width;
        int fontSize = x / 20;
        scoreAtualText.fontSize = fontSize;
        topScoreText.fontSize = fontSize;
        scoreAtualText.GetComponent<RectTransform>().position = new Vector3(100, y - 30);
        topScoreText.GetComponent<RectTransform>().position = new Vector3(100, y - x/12);
    }

    // Update is called once per frame
    void Update()
    {
        scoreAtualText.text = score.ToString();
        if (score >= topScore)
        {
            topScoreText.text = "Top " + topScore;
            topScore = score;
        }
    }
}
