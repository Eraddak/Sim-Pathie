using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Android;

public class AppManager : MonoBehaviour
{
    public GameObject blackScreen;

    private static bool isLoading = false;


    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera)) // Some devices require to be asked for permissions while others automatically do. This is for safety.
            Permission.RequestUserPermission(Permission.Camera);

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            Permission.RequestUserPermission(Permission.Microphone);
    }

    private void ChangeFilterConfig(int index)
    {
        FiltersConfigs.currentFilterIndex = index;
    }

    public void ChangeFilterIntensity(float newIntensity)
    {
        FiltersConfigs.currentIntensity = newIntensity;
    }

    private IEnumerator RotateThenLoad(ScreenOrientation orientation, string sceneName)
    {
        if (blackScreen != null)
            blackScreen.SetActive(true);
        if (Screen.orientation != orientation)
        {
            Screen.orientation = orientation; // This instruction being async, we need to wait until it's finished, 
                                              // or the start methods of the next scene will be wrong (as they depend from the screen size)
            yield return new WaitUntil(() => Screen.orientation.Equals(orientation)); // It appears that waiting for this is not enough. Certainly that the variable is assigned before
            yield return new WaitForSeconds(0.1f);                                    // the screen is actually rotated. Therefore we need to wait for an extra short time.
        }
        SceneManager.LoadScene(sceneName);
        isLoading = false;
    }

    public void LoadVisualScene(int configIndex)
    {
        if (isLoading)
            return;
        isLoading = true;
        ChangeFilterConfig(configIndex);
        Toggle toggle = GetComponentInChildren<Toggle>(); // Check if the VR check box is triggered.
        if (toggle == null || toggle.isOn)
            StartCoroutine(RotateThenLoad(ScreenOrientation.LandscapeLeft, "Visual VR Preview")); // We ask the device to rotate the screen then load the new scene (see above)
        else
            StartCoroutine(RotateThenLoad(ScreenOrientation.LandscapeLeft, "Visual"));
    }

    public void LoadVisualVRScene()
    {
        if (isLoading)
            return;
        isLoading = true;
        StartCoroutine(RotateThenLoad(ScreenOrientation.LandscapeLeft, "Visual VR"));
    }

    public void LoadUIScene()
    {
        if (isLoading)
            return;
        isLoading = true;

        StartCoroutine(RotateThenLoad(ScreenOrientation.Portrait, "UI"));
    }

    public void LoadAuditoryScene()
    {
        if (isLoading)
            return;
        isLoading = true;

        StartCoroutine(RotateThenLoad(ScreenOrientation.LandscapeLeft, "Auditory"));
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
