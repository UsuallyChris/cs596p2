using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateHeightMap{

    public static float[,] GenerateHeights(int mapWidth, int mapLength, float scale)
    {
        float[,] heights = new float[(mapWidth + 1), (mapLength + 1)];

        if (scale <= 0)
        {
            scale = 0.00000001f;
        }

        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapLength; y++)
            {
                float xScale = x / scale;
                float yScale = y / scale;
                float height = Mathf.PerlinNoise(xScale, yScale);
                heights[x, y] = height;
            }
        }
        return heights;
    }

}
