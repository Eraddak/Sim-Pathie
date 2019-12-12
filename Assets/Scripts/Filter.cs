using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Filter : MonoBehaviour
{
    public Slider wishedIntensity;
    public Color color;
    public float refreshPeriod = 0.5f; // increase performances
    protected Vector2Int screenSize;
    protected float lastIntensity;

    private float clock = 0f;

    protected virtual void Start()
    {
        GetComponent<RawImage>().color = color;
        lastIntensity = wishedIntensity.value;
        screenSize = new Vector2Int(Screen.width, Screen.height);

        RefreshIntensity(lastIntensity);

        float ratio = (float)screenSize.x / (float)screenSize.y;
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
    }

    private void Update()
    {
        clock += Time.deltaTime;
        if (clock > refreshPeriod)
        {
            if (lastIntensity != wishedIntensity.value)
            {
                lastIntensity = wishedIntensity.value;
                RefreshIntensity(lastIntensity);
            }
            clock = 0f;
        }
    }


    protected abstract void RefreshIntensity(float newIntensity);

}
