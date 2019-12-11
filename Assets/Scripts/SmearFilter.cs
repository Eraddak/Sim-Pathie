using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmearFilter : Filter
{
    public List<Smear> smears;

    protected override void RefreshIntensity(float newIntensity)
    {
        Texture2D texture = new Texture2D(screenSize.x, screenSize.y);
        GetComponent<RawImage>().texture = texture;

        for (int y = 0; y < texture.height; y++)
            for (int x = 0; x < texture.width; x++)
                texture.SetPixel(x, y, new Color(1, 1, 1, 0));

        foreach (Smear smear in smears)
        {
            float intensity = smear.coeff * newIntensity; // Define some useful variables
            float ratio = (float)screenSize.x / (float)screenSize.y;
            int opaqueDistX = Mathf.RoundToInt(intensity * (float)screenSize.x / 100f);
            int opaqueDistY = Mathf.RoundToInt(intensity * (float)screenSize.y / 100f);
            int fadeDistX = Mathf.RoundToInt((float)opaqueDistX / 2f);
            int fadeDistY = Mathf.RoundToInt((float)opaqueDistY / 2f);
            

            float a = -1f / (float)fadeDistX; // For the calcul of fade
            float b = 1f + (float)opaqueDistX / (float)fadeDistX;

            Vector2Int smearPos = smear.position;

            for (int i = smearPos.x - (opaqueDistX + fadeDistX); i < smearPos.x + (opaqueDistX + fadeDistX); i++) // We only go through the pixels in range of the smear effect.
            {
                for (int j = smearPos.y - (opaqueDistY + fadeDistY); j < smearPos.y + (opaqueDistY + fadeDistY); j++)
                {
                    if (i >= 0 && j >= 0 && i < texture.width && j < texture.height)
                    {
                        float dist = Mathf.Sqrt(Mathf.Pow((float)i, 2f) + Mathf.Pow((float)j * ratio, 2));
                        float newAlpha = 0f;
                        if (dist < opaqueDistX) // The pixel is within opaque distance
                            newAlpha = 1;
                        else // The pixel is within fade distance
                            newAlpha = texture.GetPixel(i, j).a + (a * dist + b);

                        if (newAlpha > 1) // Just a little bit of safety
                            newAlpha = 1;
                        else if (newAlpha < 0)
                            newAlpha = 0;

                        texture.SetPixel(i, j, new Color(1, 1, 1, newAlpha)); // Set the new alpha
                    }
                }
            }
        }
        texture.Apply();
    }
    
}
