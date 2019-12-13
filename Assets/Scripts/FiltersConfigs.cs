using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FiltersConfigs
{
    // Types de Smears : 
    // 0 : SmearSimple ; 1 : SmearReversed ; 2 : SmearFull ; 3 : SmearGlaucome
    public static int currentFilterIndex = 1;
    public static List<List<SmearConfig>> configs = new List<List<SmearConfig>>()
    {
        new List<SmearConfig>() // DMLA
        {
            new SmearConfig(new Vector2(50f, 50f), 1, 0)
        },
        new List<SmearConfig>() // Retinitis Pigmentosa
        {
            new SmearConfig(new Vector2(50f, 50f), 1, 1)
        },
        new List<SmearConfig>() // Cataracte
        {
            new SmearConfig(new Vector2(50f, 50f), 1, 2)
        },
        new List<SmearConfig>() // Glaucome
        {
            new SmearConfig(new Vector2(50f, 50f), 1, 1),
            new SmearConfig(new Vector2(50f, 60f), 0.5f, 3)
        }
    };
}
