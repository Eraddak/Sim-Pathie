using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SmearSmall : Smear
{
    private static int index = 0;
    public List<Sprite> sprites;

    private void Start()
    {
        if (index == sprites.Count)
            index = 0;
        if (image != null && index < sprites.Count)
        {
            image.sprite = sprites[index];
            index++;
        }
    }

    public override void UpdateSmear(float intensity)
    {
        transform.localScale = new Vector3(intensity * coeff * ratio, intensity * coeff, 1f);
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            transform.localScale /= 2;
    }
}
