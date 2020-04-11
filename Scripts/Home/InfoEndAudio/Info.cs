using UnityEngine;

public class Info : MonoBehaviour
{
    [SerializeField] GameObject InfoBar = null;

    private void OnMouseDown()
    {
        ShowOrHideInfoBar();
        GetComponent<AudioSource>().Play();
    }

    private void ShowOrHideInfoBar()
    {
        InfoBar.SetActive(!InfoBar.activeSelf);
    }
}
