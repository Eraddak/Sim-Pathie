using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SmearsConfig
{
    public static int currentFilterIndex = 0;
    public static List<List<Smear>> configs = new List<List<Smear>>()
    {
        new List<Smear>() // DMLA
        {
            new Smear(new Vector2(50, 50), 1, false)
        },
        new List<Smear>() // Retinitis Pigmentosa
        {
            new Smear(new Vector2(50, 50), 1, true)
        },
        new List<Smear>() // Glaucome
        {
            new Smear(new Vector2(50, 50), 1, true)
        }
    };
}
