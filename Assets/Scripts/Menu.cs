using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameObject personagem;
    private int posPersonagem = 0;
    private string nomePersonagemAtual;
    private string nomePersonagem;
    private int precoPersonagem = 10;

    private int money;

    private int y = Screen.height;
    private int x = Screen.width;

    public Button buttonVoltar;
    public Button buttonSound;
    public Button buttonComprar;
    public Button buttonEsquerda;
    public Button buttonDireita;

    public Sprite spriteButtonEsquerdaCinza;
    public Sprite spriteButtonDireitaCinza;

    public Sprite spriteButtonEsquerdaVerde;
    public Sprite spriteButtonDireitaVerde;

    public Sprite spriteButtonComprarCinza;
    public Sprite spriteButtonComprarVerde;

    public Sprite spriteButtonSoundVerde;
    public Sprite spriteButtonSoundCinza;

    public Text textPrice;
    public Text textMoney;
    public Text textTopScore;

    public List<GameObject> personagens;

    private float scale;
    // Use this for initialization
    void Start()
    {

        y = Screen.height;
        x = Screen.width;
        int fontSize = x / 20;
        scale = (y / 15) * 0.01f;
        int diferencaY = y / 20;
        money = Money.GetMoney();

        nomePersonagemAtual = PlayerPrefs.GetString("Personagem");
        nomePersonagem = nomePersonagemAtual;
        posPersonagem = personagens.FindIndex(p => p.name.Equals(nomePersonagem));
        personagem = personagens[posPersonagem];
        personagem.SetActive(true);

        buttonVoltar.transform.position = new Vector3(x / 20, y - (x / 20));
        buttonVoltar.transform.localScale = new Vector3(scale, scale, scale);

        buttonSound.transform.position = new Vector3(x / 20, y - ((x / 20) * 3));
        buttonSound.transform.localScale = new Vector3(scale, scale, scale);

        buttonComprar.transform.position = new Vector3(x / 2, y / 2);
        buttonComprar.transform.localScale = new Vector3(0, 0, 0);

        buttonEsquerda.transform.position = new Vector3((x / 2) - (x / 20), x / 20);
        buttonEsquerda.transform.localScale = new Vector3(scale, scale, scale);

        buttonDireita.transform.position = new Vector3((x / 2) + (x / 20), x / 20);
        buttonDireita.transform.localScale = new Vector3(scale, scale, scale);

        if (posPersonagem == 0)
        {
            buttonEsquerda.image.sprite = spriteButtonEsquerdaCinza;
        }
        else if (posPersonagem == personagens.Count - 1)
        {
            buttonDireita.image.sprite = spriteButtonDireitaCinza;
        }

        textPrice.fontSize = fontSize;
        textPrice.transform.position = new Vector3(x / 2, ((y / 10) * 2) + diferencaY);
        textPrice.text = "$ " + precoPersonagem;
        textPrice.enabled = false;

        textMoney.fontSize = fontSize;
        textMoney.transform.position = new Vector3(x - 100, y - (y / 10) + diferencaY);
        textMoney.text = "$ " + Money.GetMoney();

        textTopScore.fontSize = fontSize;
        textTopScore.transform.position = new Vector3(x - 100, y - ((y / 10) * 2) + diferencaY);
        textTopScore.text = "Top " + Score.GetScore();

    }

    // Update is called once per frame
    void Update()
    {
        if (Sound.IsSoundOn())
        {
            buttonSound.image.sprite = spriteButtonSoundVerde;
        }
        else
        {
            buttonSound.image.sprite = spriteButtonSoundCinza;
        }
    }

    private void hasPersonagem()
    {
        if (PlayerPrefs.HasKey(nomePersonagem))
        {
            buttonComprar.transform.localScale = new Vector3(0f, 0f, 0f);
            textPrice.enabled = false;
        }
        else
        {
            textPrice.enabled = true;
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

    public void ButtonSound_Click()
    {
        Sound.SwitchSound();
    }

    public void ButtonComprar_Click()
    {
        if (Money.Sacar(precoPersonagem))
        {
            PlayerPrefs.SetString(nomePersonagem, nomePersonagem);
            buttonComprar.transform.localScale = new Vector3(0f, 0f, 0f);
            textPrice.enabled = false;
            textMoney.text = "$ " + Money.GetMoney();
        }
    }

    public void ButtonEsquerda_Click()
    {
        if (posPersonagem - 1 >= 0)
        {
            personagens[posPersonagem].SetActive(false);
            posPersonagem--;
            personagens[posPersonagem].SetActive(true);

            nomePersonagem = personagens[posPersonagem].name;

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
            personagens[posPersonagem].SetActive(false);
            posPersonagem++;
            personagens[posPersonagem].SetActive(true);

            nomePersonagem = personagens[posPersonagem].name;

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

}
