using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciadorGround : MonoBehaviour
{

    private Vector2 velocidade;
    public Vector2 posicaoInicial;

    public GameObject inicio;
    public GameObject meio;
    public GameObject fim;

    public float distancia;

    public int quantidade;

    // Use this for initialization
    void Start()
    {
        Vector2 posicao = posicaoInicial;

        if (inicio != null)
        {
            Instantiate(inicio, posicao, inicio.transform.rotation);
            posicao.x += distancia;
            quantidade--;
        }

        if (fim != null)
        {
            quantidade--;
        }

        for (int i = 1; i <= quantidade; i++)
        {
            Instantiate(meio, posicao, meio.transform.rotation);
            posicao.x += distancia;
        }

        if (fim != null)
        {
            Instantiate(fim, posicao, fim.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
