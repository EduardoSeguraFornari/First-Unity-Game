using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruta : MonoBehaviour
{
    public static int quantidadeFrutas = 0;
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (quantidadeFrutas == 16)
        {
            Score.score += 10;
            quantidadeFrutas = 0;
        }
        else if (quantidadeFrutas == 5)
        {
            Score.score += 5;
        }
        else
        {
            Score.score++;
        }
        quantidadeFrutas++;
        Destroy(this.gameObject);
    }

    //void OnCollisionEnter2D(Collision2D colisor)
    //{
    //    if (colisor.gameObject.tag == "Player")
    //    {
    //    }
    //}
}
