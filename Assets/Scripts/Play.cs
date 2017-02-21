using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour {

    private float screenWidth;

    public GameObject buttonHome;
    public GameObject textMoney;
    public GameObject textScore;
    public GameObject textTopScore;

    public static bool play;

    // Use this for initialization
    void Start () {
        screenWidth = Screen.width;
        play = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).position.x>screenWidth/2))
        {
            buttonHome.SetActive(false);
            textScore.SetActive(true);
            textTopScore.SetActive(true);
            textMoney.SetActive(true);
            play = true;
        }
    }

}
