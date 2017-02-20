﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsCharacter : MonoBehaviour
{

    public GameObject player;
    private Animator animator;
    private List<string> personagens = new List<string> { "Boy", "Girl", "Cat" };
    private int posPersonagem = 0;
    private string nomePersonagem;
    public Button buttonEsquerda, buttonDireita, buttonVoltar;
    public Sprite spriteButtonEsquerdaCinza, spriteButtonDireitaCinza, spriteButtonEsquerdaVerde, spriteButtonDireitaVerde;
    // Use this for initialization
    void Start()
    {
        float y = Screen.height;
        float x = Screen.width;
        buttonEsquerda.transform.position = new Vector3((x / 2) - (x / 20), x / 20);
        buttonDireita.transform.position = new Vector3((x / 2) + (x / 20), x / 20);
        buttonVoltar.transform.position = new Vector3(x / 20, y - (x / 20));

        float scale = (y / 15) * 0.01f;
        buttonEsquerda.transform.localScale = new Vector3(scale, scale, scale);
        buttonDireita.transform.localScale = new Vector3(scale, scale, scale);
        buttonVoltar.transform.localScale = new Vector3(scale, scale, scale);

        nomePersonagem = PlayerPrefs.GetString("Personagem");
        posPersonagem = personagens.FindIndex(p => p.Equals(nomePersonagem));
        animator = player.GetComponent<Animator>();
        animator.SetTrigger(nomePersonagem + "Idle");

        if (posPersonagem == 0)
        {
            buttonEsquerda.image.sprite = spriteButtonEsquerdaCinza;
        }
        else if (posPersonagem == personagens.Count - 1)
        {
            buttonDireita.image.sprite = spriteButtonDireitaCinza;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ButtonEsquerda_Click()
    {
        if (posPersonagem - 1 >= 0)
        {
            posPersonagem--;
            nomePersonagem = personagens[posPersonagem];
            animator.SetTrigger(personagens[posPersonagem] + "Idle");

            if (posPersonagem == 0)
            {
                buttonEsquerda.image.sprite = spriteButtonEsquerdaCinza;
            }
            else if (posPersonagem == personagens.Count - 2)
            {
                buttonDireita.image.sprite = spriteButtonDireitaVerde;
            }

            if (PlayerPrefs.HasKey(nomePersonagem))
            {
                PlayerPrefs.SetString("Personagem", nomePersonagem);
            }
            else
            {

            }
        }
    }

    public void ButtonDireira_Click()
    {
        if (posPersonagem + 1 <= personagens.Count - 1)
        {
            posPersonagem++;
            nomePersonagem = personagens[posPersonagem];
            animator.SetTrigger(personagens[posPersonagem] + "Idle");

            if (posPersonagem == personagens.Count - 1)
            {
                buttonDireita.image.sprite = spriteButtonDireitaCinza;
            }
            else if (posPersonagem == 1)
            {
                buttonEsquerda.image.sprite = spriteButtonEsquerdaVerde;
            }

            if (PlayerPrefs.HasKey(nomePersonagem))
            {
                PlayerPrefs.SetString("Personagem", nomePersonagem);
            }
            else
            {

            }
        }
    }

    public void ButtonVoltar_Click()
    {
        SceneManager.LoadScene("Play");
    }

}
