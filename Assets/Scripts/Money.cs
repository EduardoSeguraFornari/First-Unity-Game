using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Text textMoney;
    public static int money;
    public static int totalMoney;
    public GameObject gameObjectMoney;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            totalMoney = PlayerPrefs.GetInt("Money");
        }

        textMoney.text = totalMoney.ToString();
        int y = Screen.height;
        int x = Screen.width;
        int fontSize = x / 20;
        textMoney.fontSize = fontSize;
        gameObjectMoney.transform.position = new Vector3((x / 22), y - (y / 8));
        float scale = (y / 15) * 0.015f;
        gameObjectMoney.transform.localScale = new Vector3(scale, scale, scale);

        textMoney.GetComponent<RectTransform>().position = new Vector3(100, y - (y / 10));
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = "$ " + (totalMoney + money);
    }

    public static void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", totalMoney + money);
    }
}
