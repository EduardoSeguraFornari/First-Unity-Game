using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    private static bool switchSound;
    private static bool soundOn;

    // Use this for initialization
    void Start()
    {
        var audioSource = this.GetComponent<AudioSource>();

        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        int sound = PlayerPrefs.GetInt("Sound");

        if (sound == 1)
        {
            audioSource.mute = false;
        }
        else
        {
            audioSource.mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var audioSource = this.GetComponent<AudioSource>();
        soundOn = !audioSource.mute;

        if (switchSound)
        {
            if (soundOn)
            {
                audioSource.mute = true;
                Debug.Log("Desligar som");
                PlayerPrefs.SetInt("Sound", 0);
            }
            else
            {
                audioSource.mute = false;
                Debug.Log("Ligar som");
                PlayerPrefs.SetInt("Sound", 1);
            }
            switchSound = false;
        }
    }

    public static bool IsSoundOn()
    {
        return soundOn;
    }

    public static void SwitchSound()
    {
        switchSound = true;
    }

}
