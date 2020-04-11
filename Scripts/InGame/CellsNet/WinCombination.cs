using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCombination : MonoBehaviour
{
    [SerializeField] Vector3 Direction = Vector3.zero;
    [SerializeField] LayerMask Layar = LayerMask.GetMask();
    private GameObject[] CellsMas = new GameObject[3];

    public bool CheckingForWin()
    {
        CriateMasFoObject();

        bool tempVelue;

        if (CellsMas.Length != 3)
            return false;

        tempVelue = CellsMas[0].GetComponent<Cells>().GetValue();
        foreach(var a in CellsMas)
        {
            if (a.GetComponent<Cells>().GetActiv())
                return false;

            if(a.GetComponent<Cells>().GetValue() != tempVelue)
            {
                return false;
            }
        }

        return true;
    }

    private void CriateMasFoObject()
    {
        float DistansRay = 20f;
        int NumberOfCells = 3;

        RaycastHit2D[] CellAray = Physics2D.RaycastAll(this.transform.position, Direction, DistansRay, Layar);
        
        if(CellAray.Length != NumberOfCells)
            return;

        for(int i = 0; i<CellAray.Length; i++)
        {
            CellsMas[i] = CellAray[i].transform.gameObject;
        }
    }
}
