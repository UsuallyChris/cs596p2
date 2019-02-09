using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateColors {

    public static Color[] GetColors(int mapWidth,int mapLength, float[,] heights, TerrainType[] regions)
    {
        Color[] colorMap = new Color[mapWidth * mapLength];

        for (int y = 0; y < mapLength; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float currentHeight = heights[x, y];
                for(int i = 0; i < regions.Length; i++)
                {
                    if(currentHeight <= regions[i].height)
                    {
                        colorMap[y * mapWidth + x] = regions[i].color;
                        break;
                    }
                }
            }
        }

        return colorMap;
    }

    public struct TerrainType
    {
        public string name;
        public float height;
        public Color color;
    }

}
