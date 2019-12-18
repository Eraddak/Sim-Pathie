using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FiltersConfigs
{
    // Types de Smears : 
    // 0 : SmearSimple ; 1 : SmearReversed ; 2 : SmearCataract ; 3 : SmearGlaucome
    public static float currentIntensity = 0.5f;
    public static int currentFilterIndex = 4;
    public static List<List<SmearConfig>> configs = new List<List<SmearConfig>>()
    {
        new List<SmearConfig>() // 0 : DMLA
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 0)
        },
        new List<SmearConfig>() // 1 : Pigmentary Retinopathy
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 1)
        },
        new List<SmearConfig>() // 2 : Cataract
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 2)
        },
        new List<SmearConfig>() // 3 : Glaucome
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 1),
            new SmearConfig(new Vector2(50f, 55f), 1f, 3)
        },
        new List<SmearConfig>() // 4 : Diabetic Retinopathy
        {
            new SmearConfig(new Vector2(15f, 55f), 1, 4),
            new SmearConfig(new Vector2(30f, 90f), 1, 4),
            new SmearConfig(new Vector2(70f, 60f), 1, 4),
            new SmearConfig(new Vector2(80f, 80f), 1, 4),
            new SmearConfig(new Vector2(35f, 25f), 1, 4),
            new SmearConfig(new Vector2(45f, 50f), 1, 4),
            new SmearConfig(new Vector2(60f, 10f), 1, 4),
            new SmearConfig(new Vector2(85f, 30f), 1, 4)
        }
    };
}
