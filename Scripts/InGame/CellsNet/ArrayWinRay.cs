using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayWinRay : MonoBehaviour
{
    [SerializeField] GameObject[] WinRay = null;

    public bool CheckWin()
    {
        foreach(var a in WinRay)
        {
            if (a.GetComponent<WinCombination>().CheckingForWin())
                return true;
        }

        return false;
    }
}
