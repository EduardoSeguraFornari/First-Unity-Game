using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarregarPersonagem : MonoBehaviour {

    public List<GameObject> personagens;
    public static GameObject personagem;

	// Use this for initialization
	void Start () {
        String nomePersonagem;
        if (PlayerPrefs.HasKey("Personagem"))
        {
            nomePersonagem = PlayerPrefs.GetString("Personagem");
        }
        else
        {
            PlayerPrefs.SetString("Personagem", "Boy");
            PlayerPrefs.SetString("Boy", "Boy");
            PlayerPrefs.SetString("Girl", "Girl");
            nomePersonagem = "Boy";
        }
        personagem = personagens.Find(p => p.name.Equals(nomePersonagem));
        personagem.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
