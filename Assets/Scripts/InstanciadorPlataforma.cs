using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorPlataforma : MonoBehaviour
{

    private Vector2 velocidade;
    private float smooth = 0f;
    private int quantidadeFrutas = 0;
    private List<int> nemeros = new List<int>{ 1, 2, 3, 5, 8, 13, 21 };

    public Vector2 posicaoInicial;
    public GameObject plataforma;
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
            var rnd = new System.Random();
            
            if (nemeros.Contains(rnd.Next(1, 35)))
            {
                posicao.x += 2;
            }
            Instantiate(plataforma, posicao, plataforma.transform.rotation);
            if (i % 5 == 0)
            {
                if (quantidadeFrutas == 16)
                {
                    posicao.y += 1;
                    Instantiate(fruta_3, posicao, fruta_3.transform.rotation);
                    quantidadeFrutas = 0;
                    posicao.y -= 1;
                }
                else if (quantidadeFrutas == 5)
                {
                    posicao.y += 1;
                    Instantiate(fruta_2, posicao, fruta_2.transform.rotation);
                    quantidadeFrutas++;
                    posicao.y -= 1;

                }
                else
                {
                    posicao.y += 1;
                    Instantiate(fruta_1, posicao, fruta_1.transform.rotation);
                    quantidadeFrutas++;
                    posicao.y -= 1;

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
