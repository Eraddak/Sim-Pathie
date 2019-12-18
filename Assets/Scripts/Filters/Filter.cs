using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    public CamDisplay camDisplayer;
    public Slider wishedIntensity;
    public Color color;
    public float refreshPeriod = 0.5f; // increase performances
    public List<GameObject> smearsPrefabs; // The list of the smears prefabs. !!!! IT MUST FOLLOW THE INDEXATION OF THE SMEAR CONFIG LIST !!!!

    private float lastIntensity;
    private List<Smear> smears;
    private WebCamTexture webCamTexture;
    private bool webCamInitialized = false;

    private void Start()
    {
        if (wishedIntensity != null)
            lastIntensity = wishedIntensity.value;
        else
            lastIntensity = FiltersConfigs.currentIntensity;

        float ratio = (float)Screen.width / (float)Screen.height;
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
        GetSmears();
        RefreshIntensity(lastIntensity);
    }

    private void Update()
    {
        if (wishedIntensity == null)
            RefreshIntensity(lastIntensity);
        if (wishedIntensity != null && lastIntensity != wishedIntensity.value)
        {
            lastIntensity = wishedIntensity.value;
            RefreshIntensity(lastIntensity);
        }
        if (!webCamInitialized)
        {
            if (camDisplayer != null) {
                this.webCamTexture = camDisplayer.webCamTexture;
                webCamInitialized = true;
            }
        }
        else
        {
            float sum = 0f;
            for (int i = 0; i < Mathf.Min(webCamTexture.width, webCamTexture.height); i++)
            {
                Color pixel = webCamTexture.GetPixel(i, i);
                sum += pixel.r;
                sum += pixel.g;
                sum += pixel.b;
            }
            sum /= Mathf.Min(webCamTexture.width, webCamTexture.height);
            sum /= 3f;
            RefreshColor(new Color(sum, sum, sum));
        }
    }

    private void GetSmears()
    {
        List<SmearConfig> configs = FiltersConfigs.configs[FiltersConfigs.currentFilterIndex];
        smears = new List<Smear>();
        foreach (SmearConfig config in configs)
        {
            GameObject newSmearObject = Instantiate(smearsPrefabs[config.type]);
            newSmearObject.transform.SetParent(transform);
            Smear newSmear = newSmearObject.GetComponent<Smear>();
            newSmear.RefreshPosition(config.position);
            newSmear.SetCoeff(config.coeff);
            smears.Add(newSmearObject.GetComponent<Smear>());
        }
    }

    private void RefreshColor(Color color)
    {
        if (smears != null)
            foreach (Smear smear in smears)
                smear.SetColor(color);
    }

    public void RefreshIntensity(float newIntensity)
    {
        if (smears != null)
            foreach (Smear smear in smears)
                smear.SetIntensity(newIntensity);
    }
}
