using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorNuven : MonoBehaviour
{

    private Vector2 velocidade;
    public Vector2 posicaoInicial;

    public GameObject nuven;

    public float distanciaX;
    public float distanciaY;

    public int quantidade;

    // Use this for initialization
    void Start()
    {
        Vector2 posicao = posicaoInicial;

        for (int i = 1; i <= quantidade; i++)
        {
            if (i % 2 == 0)
            {
                posicao.y -= distanciaY;
                Instantiate(nuven, posicao, nuven.transform.rotation);
                posicao.y += distanciaY;
            }
            else
            {
                Instantiate(nuven, posicao, nuven.transform.rotation);
            }
            posicao.x += distanciaX;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
