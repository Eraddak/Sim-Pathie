using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public bool isVROn;

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
