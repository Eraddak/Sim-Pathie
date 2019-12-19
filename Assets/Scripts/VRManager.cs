using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRManager : MonoBehaviour
{
    private static bool isActivating = true;

    private void Start()
    {
        StartCoroutine(ActivationDevice("cardboard"));
    }

    private IEnumerator ActivationDevice(string Device)
    {
        if (string.Compare(XRSettings.loadedDeviceName, Device, true) != 0)
        {
            XRSettings.LoadDeviceByName(Device);
            yield return null;
        }
        XRSettings.enabled = true;
        isActivating = false;
    }

    private IEnumerator ReturnToUI()
    {
        isActivating = true;
        StartCoroutine(ActivationDevice("None"));
        yield return new WaitUntil(() => !isActivating);
        GetComponent<AppManager>().LoadUIScene();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(ReturnToUI());
    }
}
