using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{

    private float tempoInicial;
    private float tempoFinal;

    private bool recomecar;

    public float tempoDeEspera;

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

            Score.score = 0;

            tempoInicial = Time.time;

            recomecar = true;
        }
    }

}
