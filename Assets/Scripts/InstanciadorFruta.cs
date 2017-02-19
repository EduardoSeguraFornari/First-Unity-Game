using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorFruta : MonoBehaviour
{

    private Vector2 velocidade;
    private int quantidadeFrutas = 0;

    public Vector2 posicaoInicial;
    public GameObject fruta_1;
    public GameObject fruta_2;
    public GameObject fruta_3;
    public float distancia;
    public int quantidade;

    // Use this for initialization
    void Start()
    {
        Vector2 posicao = posicaoInicial;

        for (int i = 1; i <= quantidade; i++)
        {
            if (i % 5 == 0)
            {
                if (quantidadeFrutas == 16)
                {
                    Instantiate(fruta_3, posicao, fruta_3.transform.rotation);
                    quantidadeFrutas = 0;
                }
                else if (quantidadeFrutas == 5)
                {
                    Instantiate(fruta_2, posicao, fruta_2.transform.rotation);
                    quantidadeFrutas++;
                }
                else
                {
                    Instantiate(fruta_1, posicao, fruta_1.transform.rotation);
                    quantidadeFrutas++;
                }
            }
            posicao.x += distancia;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
