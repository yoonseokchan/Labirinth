using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public void OnRetryButtonClick()
    {
        var scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
}
