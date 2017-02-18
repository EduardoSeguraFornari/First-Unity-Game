using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D rb2D;
    private Color debugCorColisao = Color.red;
    private float tempoStart;
    private bool start;

    public LayerMask layerMask;
    public Vector2 pontoColisaoPiso = Vector2.zero;
    public bool estaNoChao;
    public float raio;
    public float force;
    public bool running;
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
        IsOnGround();
        if (running)
        {
            Movimentar();
            ControlarEntradas();
        }
        else if (Input.GetButtonDown("Jump") || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            StartCoroutine(GreenYellowRed());
            start = true;
            tempoStart = Time.deltaTime;
        }
        else if (start)
        {
            if (tempoStart >= 0.3f)
            {
                animator.SetTrigger("Run");
                running = true;
            }
            tempoStart += Time.deltaTime;
        }
    }

    IEnumerator GreenYellowRed()
    {
        Debug.Log("Green");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("Yellow");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Red");
        yield return new WaitForSeconds(3.0f);
    }

    private void Movimentar()
    {
        //rb2D.transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    private void IsOnGround()
    {
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, layerMask);
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
        if (estaNoChao)
        {
            rb2D.AddForce(transform.up * force, ForceMode2D.Force);
            //rb2D.AddForce(transform.up * force * Time.deltaTime);
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
