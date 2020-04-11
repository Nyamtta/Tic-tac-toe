using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCell : MonoBehaviour
{
    [SerializeField] GameObject WinBar = null;
    [SerializeField] private float Speed = 10;
    private Vector3 ToPosition = Vector3.zero;
    private bool IsMoving;

    private void Start()
    {
        ToPosition = Vector3.zero;
        IsMoving = false;
    }

    private void Update()
    {
        if(IsMoving)
        {
            Mov();
            StopMov();
        }
    }

    private void Mov()
    {
        gameObject.transform.position = Vector3.MoveTowards(this.transform.position, ToPosition, Speed * Time.deltaTime);
    }

    private void StopMov()
    {
        if(System.Math.Round(transform.position.y, 2) == System.Math.Round(ToPosition.y, 2))
        {
            IsMoving = false;
            CheckWin();
        }
        else
            IsMoving = true;
    }

    public void StartMov(Vector3 To)
    {
        IsMoving = true;
        ToPosition = To;
    }

    private void CheckWin()
    {
        if (FindObjectOfType<ArrayWinRay>().CheckWin())
        {
            WinBar.SetActive(true);
            FindObjectOfType<TextOfSiteation>().SetText("You Win!");
            FindObjectOfType<TextOfSiteation>().PlayWinSong();
        }
    }



}
