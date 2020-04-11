using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{

    [SerializeField] float RotateAngle = 90f;
    private RotareGameNet Button;

    private void Start()
    {
        Button = FindObjectOfType<RotareGameNet>();
    }

    private void OnMouseDown()
    {
        Button.StartRotate(RotateAngle);
        GetComponent<AudioSource>().Play();
    }

}
