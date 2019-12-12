using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamDisplay : MonoBehaviour
{
    private void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture backCam = null;

        if (devices.Length <= 0)
        {
            Debug.Log("No camera detected");
            return;
        }

        foreach (WebCamDevice d in devices)
        {
            if (!d.isFrontFacing)
            {
                backCam = new WebCamTexture(d.name, Screen.width, Screen.height);
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();
        GetComponent<RawImage>().texture = backCam;

        float ratio = (float)Screen.width / (float)Screen.height;
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
    }
}
