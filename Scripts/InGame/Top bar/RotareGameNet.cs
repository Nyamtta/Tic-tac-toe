using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotareGameNet : MonoBehaviour
{
    [SerializeField] float SpeedRotate = 10f;
    private Quaternion ToThisAngel;
    private bool CanRotate;
    private bool StartRotating;
    private StartMovingRay[] RayMass;

    private void Start()
    {
        RayMass = FindObjectsOfType<StartMovingRay>();
        StartRotating = false;
        CanRotate = true;
        ToThisAngel = this.transform.rotation;
    }

    private void FixedUpdate()
    {
        if(StartRotating)
        {
            RotateThisObject();
            if(IsNotReturns())
            {
                StartRotating = false;
                DropRay();
            }
        }
    }

    private void DropRay()
    {
        if(RayMass.Length != 3)
        {
            print("Не знайшоло всіх обєктів з рей кастом");
        }
        else
        {
            foreach(var a in RayMass)
            {
                a.SvapCells();
            }
        }
    }

    private void RotateThisObject()
    {   
        var step = SpeedRotate * Time.deltaTime;
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, ToThisAngel, step);
    }

    public void StartRotate(float Angel)
    {
        if(CanRotate)
        {
            var Temp = this.transform.rotation.eulerAngles;
            ToThisAngel = Quaternion.Euler(Temp.x, Temp.y, Temp.z + Angel);
            CanRotate = false;
            StartRotating = true;
        }
    }

    public void ReadyToRotate()
    {
        CanRotate = true;
    }

    public bool IsNotReturns()
    {
        int angle = (int)this.transform.rotation.eulerAngles.z;
        switch (angle)
        {
            case 0: return true;
            case 90: return true;
            case 180: return true;
            case 270: return true;
        }
        return false;
    }

}
