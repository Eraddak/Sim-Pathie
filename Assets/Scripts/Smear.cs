using UnityEngine;
using System;

[Serializable]
public class Smear
{
    public Vector2 position = Vector2.zero;
    public float coeff = 1;
    public bool isReversed = false;

    public Smear()
    {
        position = Vector2.zero;
        coeff = 1;
        isReversed = false;
    }
    public Smear(Vector2 position, float coeff, bool isReversed)
    {
        this.position = position;
        this.coeff = coeff;
        this.isReversed = isReversed;
    }
}
