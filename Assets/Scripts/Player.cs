using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2D;
    private Color debugCorColisao = Color.red;
    private float tempoStart;
    private float tempoNoAr = 0;
    private int pulou = 0;
    private bool running;

    public LayerMask layerMask;
    public Vector2 pontoColisaoPiso = Vector2.zero;
    public float raio;
    public float force;
    public float velocidade;

    // Use this for initialization
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (running)
        {
            if (IsOnGround())
            {
                tempoNoAr = 0;
                pulou = 0;
                force = 1000;
            }
            if (pulou > 0)
            {
                tempoNoAr += Time.fixedDeltaTime;
            }
            Movimentar();
            ControlarEntradas();
        }
        else if (Play.play)
        {
            if (tempoStart >= 0.3f)
            {
                animator.SetTrigger(this.name + "Run");
                running = true;
            }
            tempoStart += Time.fixedDeltaTime;
        }
    }

    private void Movimentar()
    {
        //rb2D.transform.Translate(Vector2.right * velocidade * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * velocidade * Time.fixedDeltaTime);
    }

    private bool IsOnGround()
    {
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        return Physics2D.OverlapCircle(pontoPosicao, raio, layerMask);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = debugCorColisao;
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        Gizmos.DrawWireSphere(pontoPosicao, raio);
    }

    private void Pular()
    {
        //if (estaNoChao && rb2D.velocity.y <= 0)
        if (IsOnGround() || (tempoNoAr >= 0.18f && pulou == 1))
        {
            rb2D.AddForce(transform.up * force, ForceMode2D.Force);
            force = 600;
            pulou++;
        }
    }

    private void ControlarEntradas()
    {
        if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            Pular();
        }
    }
}
