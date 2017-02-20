using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHome : MonoBehaviour
{

    public GameObject buttonHome;

    // Use this for initialization
    void Start()
    {
        float y = Screen.height;
        float x = Screen.width;
        buttonHome.transform.position = new Vector3(x / 20, y - (x / 20));
        float scale = (y / 15) * 0.01f;
        buttonHome.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void ButtonHome_Click()
    {
        SceneManager.LoadScene("Character");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
