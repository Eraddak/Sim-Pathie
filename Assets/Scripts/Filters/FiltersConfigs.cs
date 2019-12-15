﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FiltersConfigs
{
    // Types de Smears : 
    // 0 : SmearSimple ; 1 : SmearReversed ; 2 : SmearCataract ; 3 : SmearGlaucome
    public static float currentIntensity = 0.5f;
    public static int currentFilterIndex = 0;
    public static List<List<SmearConfig>> configs = new List<List<SmearConfig>>()
    {
        new List<SmearConfig>() // 0 : DMLA
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 0, Color.grey)
        },
        new List<SmearConfig>() // 1 : Retinitis Pigmentosa
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 1, Color.grey)
        },
        new List<SmearConfig>() // 2 : Cataract
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 2, Color.grey)
        },
        new List<SmearConfig>() // 3 : Glaucome
        {
            new SmearConfig(new Vector2(50f, 50f), 1f, 1, Color.black),
            new SmearConfig(new Vector2(50f, 55f), 1f, 3, Color.black)
        }
    };
}