using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SmearSimple : Smear
{
    public override void UpdateSmear(float intensity)
    {
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            intensity /= 2f;
        transform.localScale = new Vector3(intensity * coeff * ratio, intensity * coeff, 1f);
    }
}
