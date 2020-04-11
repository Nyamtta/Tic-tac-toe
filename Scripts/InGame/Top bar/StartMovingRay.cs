using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMovingRay : MonoBehaviour
{
    [SerializeField] private LayerMask CellLayer = LayerMask.GetMask();
    private RaycastHit2D[] CellToMov = null;
    
    public void SvapCells()
    {
        float _distans = 10f;
        CellToMov = Physics2D.RaycastAll(transform.position, Vector3.down, _distans, CellLayer);

        MovCell(CellToMov);
    }
    
    private void MovCell(RaycastHit2D[] cell)
    {
        Vector3 PositionToMov0;
        Vector3 PositionToMov1;
        Vector3 PositionToMov2;


        if (cell.Length != 3)
        {
            return;
        }
        else
        {
            PositionToMov0 = cell[0].transform.position;
            PositionToMov1 = cell[1].transform.position;
            PositionToMov2 = cell[2].transform.position;
        }

        if( cell[0].transform.GetComponent<Cells>().GetActiv() == false &&
            cell[1].transform.GetComponent<Cells>().GetActiv() == true &&
            cell[2].transform.GetComponent<Cells>().GetActiv() == true)
        {
            cell[0].transform.GetComponent<MovCell>().StartMov(PositionToMov2);
            cell[2].transform.GetComponent<MovCell>().StartMov(PositionToMov0);
        }
        if (cell[0].transform.GetComponent<Cells>().GetActiv() == false &&
            cell[1].transform.GetComponent<Cells>().GetActiv() == false &&
            cell[2].transform.GetComponent<Cells>().GetActiv() == true)
        {
            cell[0].transform.GetComponent<MovCell>().StartMov(PositionToMov1);
            cell[1].transform.GetComponent<MovCell>().StartMov(PositionToMov2);
            cell[2].transform.GetComponent<MovCell>().StartMov(PositionToMov0);
        }
        if (cell[0].transform.GetComponent<Cells>().GetActiv() == false &&
            cell[1].transform.GetComponent<Cells>().GetActiv() == true &&
            cell[2].transform.GetComponent<Cells>().GetActiv() == false)
        {
            cell[0].transform.GetComponent<MovCell>().StartMov(PositionToMov1);
            cell[1].transform.GetComponent<MovCell>().StartMov(PositionToMov0);
        }
        if (cell[0].transform.GetComponent<Cells>().GetActiv() == true &&
            cell[1].transform.GetComponent<Cells>().GetActiv() == false &&
            cell[2].transform.GetComponent<Cells>().GetActiv() == true)
        {
            cell[1].transform.GetComponent<MovCell>().StartMov(PositionToMov2);
            cell[2].transform.GetComponent<MovCell>().StartMov(PositionToMov1);
        }

    }


}
