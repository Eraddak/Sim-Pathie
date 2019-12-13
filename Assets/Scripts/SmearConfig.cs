using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmearConfig {
    public Vector2 position;
    public float coeff;
    public int type; // 0 : SmearSimple ; 1 : SmearReversed ; 2 : SmearFull ; 3 : SmearGlaucome

    public SmearConfig()
    {
        position = new Vector2(50f, 50f); // center
        coeff = 1f;
        type = 0;
    }

    public SmearConfig(Vector2 position, float coeff, int type)
    {
        this.position = position;
        this.coeff = coeff;
        this.type = type;
    }
}
