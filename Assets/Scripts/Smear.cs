using UnityEngine;
using System;

public abstract class Smear : MonoBehaviour
{
    public Vector2 position = Vector2.zero;
    public float coeff = 1; // affects intensity (clamp 0-1)
    protected float ratio = 1f;

    private void Awake()
    {
        ratio = (float)Screen.width / (float)Screen.height;
        RefreshPosition();
    }

    public abstract void UpdateSmear(float intensity);

    public void RefreshPosition()
    {
        transform.position = new Vector3(position.x * Screen.width / 100f, position.y * Screen.height / 100f, 0f);
    }

    public void RefreshPosition(Vector2 newPosition)
    {
        position = newPosition;
        transform.position = new Vector3(position.x * Screen.width / 100f, position.y * Screen.height / 100f, 0f);
    }

    public void SetCoeff(float newCoeff)
    {
        this.coeff = newCoeff;
    }
}
