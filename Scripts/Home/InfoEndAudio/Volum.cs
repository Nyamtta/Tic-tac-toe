using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volum : MonoBehaviour
{
    [SerializeField] private Sprite NewSprite;

    private void Start()
    {
        MadeSoundValues();
        CheckActivSound();
    }

    private void OnMouseDown()
    {
        ChangeSprite();
        GetComponent<AudioSource>().Play();
        OnOfSound();
        
    }

    public void OnOfSound()
    {     

        if (PlayerPrefs.GetInt("sound") == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            AudioListener.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
            AudioListener.volume = 1;
        }

    }

    public void ChangeSprite()
    {
        Sprite tempImage;
        SpriteRenderer MainSprite = gameObject.GetComponent<SpriteRenderer>();

        tempImage = MainSprite.sprite;
        MainSprite.sprite = NewSprite;
        NewSprite = tempImage;
    }

    private void MadeSoundValues()
    {
        if (PlayerPrefs.HasKey("sound") == false)
            PlayerPrefs.SetInt("sound", 1);
    }

    private void CheckActivSound()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            ChangeSprite();
            AudioListener.volume = 0;
        }
    }
}
