using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;


public class GoTuNehtScenes : MonoBehaviour
{
    [SerializeField] int IndexsNextScene = 0;

    private void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(IndexsNextScene, LoadSceneMode.Single);
    }
}
