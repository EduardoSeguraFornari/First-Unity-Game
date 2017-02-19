using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruta : MonoBehaviour
{
    [SerializeField]
    private int valor;

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Score.score += valor;
        Destroy(this.gameObject);
    }

    //void OnCollisionEnter2D(Collision2D colisor)
    //{
    //    if (colisor.gameObject.tag == "Player")
    //    {
    //    }
    //}
}
