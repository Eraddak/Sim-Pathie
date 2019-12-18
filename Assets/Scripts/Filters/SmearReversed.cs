using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SmearReversed : Smear
{
    public override void UpdateSmear(float intensity)
    {
        float x = intensity * coeff;
        transform.localScale = new Vector3((1 - x) * ratio * 29 + ratio, (1 - x) * 29 + 1f, 0f);
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            transform.localScale /= 2;
    }
}
