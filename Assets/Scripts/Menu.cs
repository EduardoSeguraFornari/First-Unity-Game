using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject player;
    private Animator animator;
    private List<string> personagens = new List<string> { "Boy", "Girl", "Cat", "Dog", "MaleZombie", "FemaleZombie", "Jack", "Knight", "NinjaAdventure", "NinjaGirl", "Robot", "SantaClaus" };
    private int posPersonagem = 0;
    private string nomePersonagemAtual, nomePersonagem;
    private int money;
    private int precoPersonagem = 10;

    public Button buttonEsquerda, buttonDireita, buttonVoltar, buttonComprar;
    public Sprite spriteButtonEsquerdaCinza, spriteButtonDireitaCinza, spriteButtonEsquerdaVerde, spriteButtonDireitaVerde, spriteButtonComprarCinza, spriteButtonComprarVerde;
    public Text textMoney, textTopScore;

    private float scale;
    // Use this for initialization
    void Start()
    {

        int y = Screen.height;
        int x = Screen.width;
        int fontSize = x / 20;
        scale = (y / 15) * 0.01f;
        int diferencaY = y / 20;
        money = Money.GetMoney();

        textMoney.fontSize = fontSize;
        textMoney.transform.position = new Vector3(x - 100, y - (y / 10) + diferencaY);
        textMoney.text = "$ " + Money.GetMoney();

        textTopScore.fontSize = fontSize;
        textTopScore.transform.position = new Vector3(x - 100, y - ((y / 10) * 2) + diferencaY);
        textTopScore.text = "Top " + Score.GetScore();

        buttonEsquerda.transform.position = new Vector3((x / 2) - (x / 20), x / 20);
        buttonEsquerda.transform.localScale = new Vector3(scale, scale, scale);

        buttonDireita.transform.position = new Vector3((x / 2) + (x / 20), x / 20);
        buttonDireita.transform.localScale = new Vector3(scale, scale, scale);

        buttonVoltar.transform.position = new Vector3(x / 20, y - (x / 20));
        buttonVoltar.transform.localScale = new Vector3(scale, scale, scale);

        buttonComprar.transform.position = new Vector3(x / 2, y / 2);
        buttonComprar.transform.localScale = new Vector3(scale, scale, scale);

        nomePersonagemAtual = PlayerPrefs.GetString("Personagem");
        nomePersonagem = PlayerPrefs.GetString("Personagem");
        posPersonagem = personagens.FindIndex(p => p.Equals(nomePersonagem));
        animator = player.GetComponent<Animator>();
        animator.SetTrigger(nomePersonagem + "Idle");

        buttonComprar.transform.localScale = new Vector3(0f, 0f, 0f);

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

    private void hasPersonagem()
    {
        if (PlayerPrefs.HasKey(nomePersonagem))
        {
            buttonComprar.transform.localScale = new Vector3(0f, 0f, 0f);
        }
        else
        {
            buttonComprar.transform.localScale = new Vector3(scale, scale, scale);
            if (Money.ValidaSaque(precoPersonagem))
            {
                buttonComprar.image.sprite = spriteButtonComprarVerde;
            }
            else
            {
                buttonComprar.image.sprite = spriteButtonComprarCinza;
            }
        }
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
            hasPersonagem();
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
            hasPersonagem();
        }
    }

    public void ButtonComprar_Click()
    {
        if (Money.Sacar(precoPersonagem))
        {
            PlayerPrefs.SetString(nomePersonagem, nomePersonagem);
            buttonComprar.transform.localScale = new Vector3(0f, 0f, 0f);
            textMoney.text = "$ " + Money.GetMoney();
        }
    }

    public void ButtonVoltar_Click()
    {
        if (PlayerPrefs.HasKey(nomePersonagem))
        {
            PlayerPrefs.SetString("Personagem", nomePersonagem);
        }
        else
        {
            PlayerPrefs.SetString("Personagem", nomePersonagemAtual);
        }
        SceneManager.LoadScene("Play");
    }

}
