using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmearCataract : Smear
{
    Image currentColor;

    private void Start()
    {
        currentColor = GetComponent<Image>();
    }

    public override void UpdateSmear(float intensity)
    {
        currentColor.color = new Color(currentColor.color.r, currentColor.color.g, currentColor.color.b, intensity);
    }
}
