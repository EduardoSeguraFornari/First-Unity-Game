using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{
    public Transform transform;
    public float smooth = 0.5f;
    private Vector2 velocidade;
    // Use this for initialization
    void Start()
    {
        velocidade = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPosicao2D = Vector2.zero;
        novaPosicao2D.x = Mathf.SmoothDamp(base.transform.position.x, transform.position.x + 5, ref velocidade.x, smooth);
        novaPosicao2D.y = Mathf.SmoothDamp(base.transform.position.y, base.transform.position.y, ref velocidade.y, smooth);
        Vector3 novaPosicao = new Vector3(novaPosicao2D.x, novaPosicao2D.y, base.transform.position.z);
        base.transform.position = Vector3.Slerp(base.transform.position, novaPosicao, Time.time);
    }
}
