﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour {

    public GameObject player;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            Destroy(player);
            Score.score = 0;
            Fruta.quantidadeFrutas = 0;
            SceneManager.LoadScene("Play");
        }
    }

}