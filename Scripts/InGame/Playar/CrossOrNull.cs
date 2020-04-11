using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossOrNull : MonoBehaviour
{

    [SerializeField] private Sprite X = null;
    [SerializeField] private Sprite O = null;
    
    private bool TheSide;


    private void Start()
    {
        TheSide = true;
    }

    private void ChengSide()
    {
        TheSide = !TheSide;
    }

    public Sprite GetParametersSide(out bool side)
    {
        if (TheSide)
        {
            side = TheSide;
            ChengSide();
            return X;
        }
        else
        {
            side = TheSide;
            ChengSide();
            return O;
        }
    }
}
