using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamDisplay : MonoBehaviour
{
    public WebCamTexture webCamTexture;

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
            if (!d.isFrontFacing) // We are looking for the back camera
            {
                backCam = new WebCamTexture(d.name, Screen.width, Screen.height);
                this.webCamTexture = backCam;
            }
        }

        if (backCam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();
        GetComponent<RawImage>().texture = backCam; // Apply the webCamTexture to a UI image

        float ratio = (float)Screen.width / (float)Screen.height; // Set the AspectRatioFitter to fill the entire screen
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
    }
}
