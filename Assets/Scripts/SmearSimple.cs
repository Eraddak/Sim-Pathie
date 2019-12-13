using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearSimple : Smear
{
    public override void UpdateSmear(float intensity)
    {
        transform.localScale = new Vector3(intensity * coeff * ratio, intensity * coeff, 1f);
    }
}
