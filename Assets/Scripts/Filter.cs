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
    private Vector2Int screenSize;
    private float lastIntensity;
    private List<Smear> smears;
    private float clock = 0f;

    private void Start()
    {
        //GetComponent<RawImage>().color = color;
        lastIntensity = wishedIntensity.value;
        screenSize = new Vector2Int(Screen.width, Screen.height);
        float ratio = (float)screenSize.x / (float)screenSize.y;
        GetComponent<AspectRatioFitter>().aspectRatio = ratio;
        GetSmears();
        RefreshIntensity(lastIntensity);
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

    private void RefreshIntensity(float newIntensity)
    {
        if (smears != null)
            foreach (Smear smear in smears)
                smear.UpdateSmear(newIntensity);
    }

}
