using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBeckground : MonoBehaviour
{
    [SerializeField] float SpeedRatate = 5;

    private void FixedUpdate()
    {
        gameObject.transform.Rotate(Vector3.forward, SpeedRatate * Time.deltaTime);
    }

}
