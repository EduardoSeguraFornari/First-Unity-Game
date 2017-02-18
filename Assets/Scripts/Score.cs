using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text_1;
    public static int score;

    // Use this for initialization
    void Start()
    {
        int y = Screen.height;
        int x = Screen.width;
        int fontSize = x / 20;
        text_1.fontSize = fontSize;
        text_1.GetComponent<RectTransform>().position = new Vector3(100, y - 30);
    }

    // Update is called once per frame
    void Update()
    {
        text_1.text = score.ToString();
    }
}
