using UnityEngine;
using System.Collections;
using UnityEngine.Android;
using LibPDBinding;

public class PdManager : MonoBehaviour {

    void Start()
    {
    #if PLATFORM_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    #endif
    }

    public void OnPress(string val)
    {
        LibPD.SendFloat(val, 1);
    }
}



