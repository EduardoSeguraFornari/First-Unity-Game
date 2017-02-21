using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour
{

    private Vector2 velocidade;

    private Transform player;

    private float smooth = 0.5f;
    
    // Use this for initialization
    void Start()
    {
        velocidade = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = CarregarPersonagem.personagem.transform;
        }
        else
        {
            Vector2 novaPosicao2D = Vector2.zero;
            novaPosicao2D.x = Mathf.SmoothDamp(base.transform.position.x, player.position.x + 5, ref velocidade.x, smooth);
            novaPosicao2D.y = Mathf.SmoothDamp(base.transform.position.y, base.transform.position.y, ref velocidade.y, smooth);
            Vector3 novaPosicao = new Vector3(novaPosicao2D.x, novaPosicao2D.y, base.transform.position.z);
            base.transform.position = Vector3.Slerp(base.transform.position, novaPosicao, Time.time);
        }
    }
}
