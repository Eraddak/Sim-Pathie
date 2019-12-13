using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{

    public void LoadVisualScene()
    {
        Toggle toggle = GetComponentInChildren<Toggle>();
        if (toggle.isOn) SceneManager.LoadScene("Visual VR");
        else SceneManager.LoadScene("Visual");
    }

    public void LoadUIScene()
    {
        SceneManager.LoadScene("UI");
    }

    public void LoadAuditoryScene()
    {
        SceneManager.LoadScene("Auditory");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
