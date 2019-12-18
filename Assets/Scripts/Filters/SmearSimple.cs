using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SmearSimple : Smear
{
    public override void UpdateSmear(float intensity)
    {
        transform.localScale = new Vector3(intensity * coeff * ratio, intensity * coeff, 1f);
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            transform.localScale /= 2;
    }
}
