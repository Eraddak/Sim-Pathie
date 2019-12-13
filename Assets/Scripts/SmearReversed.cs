using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearReversed : Smear
{
    public override void UpdateSmear(float intensity)
    {
        float x = intensity * coeff;
        transform.localScale = new Vector3((1 - x) * ratio * 19 + ratio, (1 - x) * 19 + 1, 0f);
    }
}
