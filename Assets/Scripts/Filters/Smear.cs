using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR;

public abstract class Smear : MonoBehaviour
{
    public Vector2 position = Vector2.zero;
    public float coeff = 1; // affects intensity (clamp 0-1)
    protected float ratio = 1f;
    protected float intensity = 0f;
    private Image color;
    private void Awake()
    {
        RefreshRatio();
        color = GetComponent<Image>();
    }

    public abstract void UpdateSmear(float intensity);

    public void RefreshPosition()
    {
        transform.localPosition = new Vector3((position.x - 50f) * Screen.width / 100f, (position.y - 50f) * Screen.height / 100f, 0f);
    }

    public void RefreshPosition(Vector2 newPosition)
    {
        position = newPosition;
        RefreshPosition();
    }

    public void SetCoeff(float newCoeff)
    {
        this.coeff = newCoeff;
    }

    private void RefreshRatio()
    {
        ratio = (float)Screen.width / (float)Screen.height;
        RefreshPosition();
    }

    public void SetIntensity(float newIntensity)
    {
        intensity = newIntensity;
        UpdateSmear(intensity);
    }

    public void SetColor(Color color)
    {
        this.color.color = new Color(color.r, color.g, color.b, this.color.color.a);
    }

    private void Update()
    {
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            transform.rotation = FindObjectOfType<Camera>().transform.rotation;
    }
}
