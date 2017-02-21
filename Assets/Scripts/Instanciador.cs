using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instanciador : MonoBehaviour
{

    public Vector2 posicaoInicial;

    public GameObject gameObject;

    public float distancia;

    public int quantidade;

    // Use this for initialization
    void Start()
    {
        Vector2 posicao = posicaoInicial;

        for (int i = 1; i <= quantidade; i++)
        {
            Instantiate(gameObject, posicao, gameObject.transform.rotation);
            posicao.x += distancia;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
