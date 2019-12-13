using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fitter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float ratio = (float)Screen.width / (float)Screen.height;
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
    
    }
}
