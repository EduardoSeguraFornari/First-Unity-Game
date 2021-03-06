﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{

    private float tempoInicial;
    private float tempoFinal;

    private bool recomecar;

    public float tempoDeEspera;

    public AudioClip clip;

    // Use this for initialization
    void Start()
    {
        recomecar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tempoFinal - tempoInicial >= tempoDeEspera && recomecar)
        {
            Score.score = 0;
            SceneManager.LoadScene("Play");
        }
        else if (recomecar)
        {
            tempoFinal += Time.time;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            CarregarPersonagem.personagem.SetActive(false);

            Money.SaveMoney();

            tempoInicial = Time.time;

            if (Sound.IsSoundOn())
            {
                SomBolhas();
            }

            recomecar = true;
        }
    }

    public void SomBolhas()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

}
