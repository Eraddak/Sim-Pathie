using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    public Slider wishedIntensity;
    public Color color;
    public float refreshPeriod = 0.5f; // increase performances
    public List<GameObject> smearsPrefabs; // The list of the smears prefabs. !!!! IT MUST FOLLOW THE INDEXATION OF THE SMEAR CONFIG LIST !!!!

    private float lastIntensity;
    private List<Smear> smears;

    private void Start()
    {
        //GetComponent<RawImage>().color = color;
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
    }

    private void GetSmears()
    {
        List<SmearConfig> configs = FiltersConfigs.configs[FiltersConfigs.currentFilterIndex];
        smears = new List<Smear>();
        foreach (SmearConfig config in configs)
        {
            GameObject newSmearObject = Instantiate(smearsPrefabs[config.type]);
            newSmearObject.transform.SetParent(transform);
            newSmearObject.GetComponent<Image>().color = config.color;
            Smear newSmear = newSmearObject.GetComponent<Smear>();
            newSmear.RefreshPosition(config.position);
            newSmear.SetCoeff(config.coeff);
            smears.Add(newSmearObject.GetComponent<Smear>());

        }
    }

    public void RefreshIntensity(float newIntensity)
    {
        if (smears != null)
            foreach (Smear smear in smears)
                smear.UpdateSmear(newIntensity);
    }

}
