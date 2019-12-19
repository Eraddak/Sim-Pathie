using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    public CamDisplay camDisplayer;
    public Slider wishedIntensity;
    public Color color;
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
        if (!webCamInitialized) // Initialize the webCamTexture
        {
            if (camDisplayer != null) {
                this.webCamTexture = camDisplayer.webCamTexture;
                webCamInitialized = true;
            }
        }
        else // Get a global color by browsing the diagonal of pixels and make a mean of it.
        { // It allows to have more realistic smears.
            float sumR = 0f;
            float sumG = 0f;
            float sumB = 0f;
            for (int i = 0; i < Mathf.Min(webCamTexture.width, webCamTexture.height); i++)
            {
                Color pixel = webCamTexture.GetPixel(i, i);
                sumR += pixel.r;
                sumG += pixel.g;
                sumB += pixel.b;
            }
            sumR /= Mathf.Min(webCamTexture.width, webCamTexture.height);
            sumG /= Mathf.Min(webCamTexture.width, webCamTexture.height);
            sumB /= Mathf.Min(webCamTexture.width, webCamTexture.height);
            RefreshColor(new Color(sumR, sumG, sumB));
        }
    }

    private void GetSmears()
    {
        List<SmearConfig> configs = FiltersConfigs.configs[FiltersConfigs.currentFilterIndex];
        smears = new List<Smear>();
        foreach (SmearConfig config in configs) // Instantiate the smears depending on the chosen config
        {
            GameObject newSmearObject = Instantiate(smearsPrefabs[config.type]);
            newSmearObject.transform.SetParent(transform);
            Smear newSmear = newSmearObject.GetComponent<Smear>();
            newSmear.RefreshPosition(config.position);
            newSmear.SetCoeff(config.coeff);
            newSmear.fitter = GetComponent<AspectRatioFitter>().aspectRatio;
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
