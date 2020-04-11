using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cells : MonoBehaviour
{
    [SerializeField] GameObject WinBar = null;
    private CrossOrNull Side;
    private SpriteRenderer ThisSprite;
    private bool ActivCell;
    private bool CrossOrNail;

    
    private void Start()
    {
        Side = Camera.main.GetComponent<CrossOrNull>();
        ActivCell = true;
        CrossOrNail = false;
        ThisSprite = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (ClickIsActiv())
        {
            FindObjectOfType<RotareGameNet>().ReadyToRotate();
            ThisSprite.sprite = Side.GetParametersSide(out CrossOrNail);
            ExcludeСell();
            CheckWin();
            CheckDraw();
        }
    }

    public bool GetValue()
    {
        return CrossOrNail;
    }

    public bool GetActiv()
    {
        return ActivCell;
    }

    public void ExcludeСell()
    {
        ActivCell = false;
    }

    private bool ClickIsActiv()
    {
        if(FindObjectOfType<RotareGameNet>().IsNotReturns() && ActivCell)
        {
            return true;
        }

        return false;
    }

    private void CheckWin()
    {
        if (FindObjectOfType<ArrayWinRay>().CheckWin())
        {
            WinBar.SetActive(true);
            FindObjectOfType<TextOfSiteation>().SetText("You Win!");
        }
    }

    private void CheckDraw()
    {
        Cells[] temp;
        bool ActivCel = false;
        temp = FindObjectsOfType<Cells>();

        if (temp.Length != 9)
            return;
        foreach (var a in temp)
        {
            if (a.GetActiv() != ActivCel)
            {
                return; 
            }
        }
        WinBar.SetActive(true);
        FindObjectOfType<TextOfSiteation>().SetText("Draw");
        FindObjectOfType<TextOfSiteation>().PlayWinSong();
    }

}
