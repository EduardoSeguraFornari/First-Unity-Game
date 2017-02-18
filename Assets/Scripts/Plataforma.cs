using UnityEngine;
using System.Collections;

public class Plataforma : MonoBehaviour {
	private bool pisou;
	private float tempoVida;
	public float tempoMaximoVida = 0.4f;
    public AudioClip clip;
	// Use this for initialization
	void Start () {
		tempoVida = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (pisou) {
			tempoVida += Time.deltaTime;
            if (tempoVida >= tempoMaximoVida){
                Destroy(this.gameObject);
			}		
		}
	}

	void OnCollisionEnter2D(Collision2D colisor){
		if (colisor.gameObject.tag == "Player") {
            SomPlataformaQuabranco();
            pisou = true;
		}
	}

    public void SomPlataformaQuabranco()
    {
        AudioSource audio = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
