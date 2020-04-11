using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextOfSiteation : MonoBehaviour
{

    public void SetText(string Situation)
    {
        GetComponent<TextMeshProUGUI>().text = Situation;
    }

    public void PlayWinSong()
    {
        GetComponent<AudioSource>().Play();
    }

}
