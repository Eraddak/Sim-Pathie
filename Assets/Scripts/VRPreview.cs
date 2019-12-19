using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPreview : MonoBehaviour
{

    public Slider intensity;

    void Update()
    {
        if (intensity != null)
            FiltersConfigs.currentIntensity = intensity.value;
    }
}
