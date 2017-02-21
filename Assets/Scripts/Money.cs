using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{

    public Text textMoney;

    public static int money;
    public static int totalMoney;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            totalMoney = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
        }

        int y = Screen.height;
        int x = Screen.width;

        int fontSize = x / 20;

        int diferencaY = y / 20;

        float scale = (y / 15) * 0.015f;

        money = 0;

        textMoney.fontSize = fontSize;
        textMoney.text = totalMoney.ToString();
        textMoney.GetComponent<RectTransform>().position = new Vector3(100, y - (y / 10) + diferencaY);
    }

    // Update is called once per frame
    void Update()
    {
        textMoney.text = "$ " + (totalMoney + money);
    }

    public static void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", money + totalMoney);
    }

    public static int GetMoney()
    {
        return PlayerPrefs.GetInt("Money");
    }

    public static bool ValidaSaque(int money)
    {
        int saldo = PlayerPrefs.GetInt("Money");

        if (saldo < money)
        {
            return false;
        }

        return true;
    }

    public static bool Sacar(int money)
    {
        if (ValidaSaque(money))
        {
            int saldo = PlayerPrefs.GetInt("Money");
            PlayerPrefs.SetInt("Money", saldo - money);
            return true;
        }

        return false;
    }

}
