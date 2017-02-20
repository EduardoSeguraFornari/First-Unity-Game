using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorPlataforma : MonoBehaviour
{

    private Vector2 velocidade;
    private int quantidadeFrutas = 0;
    private List<int> numeros = new List<int> { 1, 2, 3, 5, 8, 13, 21 };
    private List<int> numerosUsados = new List<int>();
    private int count = 0;
    private int numero;

    public Vector2 posicaoInicial;
    public GameObject plataforma;
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    public float distancia;
    public int quantidade;

    // Use this for initialization
    void Start()
    {
        Vector2 posicao = posicaoInicial;
        var rnd = new System.Random();
        for (int i = 1; i <= quantidade; i++)
        {
            if (count == 0)
            {
                numero = 0;
                if (numerosUsados.Count == numeros.Count)
                {
                    numerosUsados.Clear();
                }
                while (!numeros.Contains(numero) || numerosUsados.Contains(numero))
                {
                    numero = rnd.Next(1, 35);
                }
                numerosUsados.Add(numero);
            }

            if (count == numero)
            {
                posicao.x += 2;
                count = 0;
            }
            else
            {
                count++;
            }


            Instantiate(plataforma, posicao, plataforma.transform.rotation);
            if (i % 5 == 0)
            {
                if (quantidadeFrutas == 16)
                {
                    posicao.y += 1;
                    Instantiate(item_3, posicao, item_3.transform.rotation);
                    quantidadeFrutas = 0;
                    posicao.y -= 1;
                }
                else if (quantidadeFrutas == 5)
                {
                    posicao.y += 1;
                    Instantiate(item_2, posicao, item_2.transform.rotation);
                    quantidadeFrutas++;
                    posicao.y -= 1;

                }
                else
                {
                    posicao.y += 1;
                    Instantiate(item_1, posicao, item_1.transform.rotation);
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
