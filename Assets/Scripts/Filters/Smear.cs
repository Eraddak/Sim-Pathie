using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.XR;

public abstract class Smear : MonoBehaviour
{
    public Vector2 position = Vector2.zero;
    public float coeff = 1; // affects intensity (clamp 0-1)
    public float fitter;

    protected float ratio = 1f;
    protected float intensity = 0f;
    protected Image image;

    private float delay = 0f;

    private void Awake()
    {
        RefreshRatio();
        image = GetComponent<Image>();
    }

    public abstract void UpdateSmear(float intensity);

    public void RefreshPosition()
    {
        Vector2 newPosition;
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0) // If we are in VR, we need to reduce the difference from the center by 2. Because the screen is actually 2 times smaller
            newPosition = new Vector2((position.x + 50f) / 2f, (position.y + 50f) / 2f);
        else
            newPosition = position;
        // According to the documentation, Transform.localPosition take into account the scale of its ancestors. In our case, the AspectRatioFitter of the object Filter affects the smears
        // Therefore we need to divide by the fitter to keep the right position, whatever the screenSize is.
        transform.localPosition = new Vector3((newPosition.x - 50f) * Screen.width / (100f * fitter), (newPosition.y - 50f) * Screen.height / (100f * fitter), 0f);
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
        this.image.color = new Color(color.r, color.g, color.b, this.image.color.a);
    }

    private void Update()
    {
        // If we are in VR, the UI moves with the camera rotation. We need to keep track of it and apply it to the smears.
        if (string.Compare(XRSettings.loadedDeviceName, "cardboard", true) == 0)
            transform.rotation = FindObjectOfType<Camera>().transform.rotation;
        if (delay < 3f)
        {
            RefreshPosition();
            delay += Time.deltaTime;
        }
    }
}
