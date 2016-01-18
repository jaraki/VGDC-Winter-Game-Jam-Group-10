using UnityEngine;
using System.Collections;

public class PlatformGenerator : BaseGenerator {
    public int minPlatformWidth;
    public int maxPlatformWidth;
    public int minDistanceBetween;
    public int maxDistanceBetween;
    public int yOffset;
    public float enemyFreq;

    public void GenerateMap()
    {
        int xIndex = 1;
        while(xIndex < MapWidth)
        {
            int platformWidth = Random.Range(minPlatformWidth, maxPlatformWidth);
            int distanceBetween = Random.Range(minDistanceBetween, maxDistanceBetween);
            int y = Random.Range(yOffset + 1, MapHeight - 1);
            bool spawnEnemy = Random.Range(0f, 1f) < enemyFreq;
            if (platformWidth + xIndex < MapWidth)
            {
                bool spawnedItem = false;
                bool spawnedEnemy = false;
                for (int x = xIndex; x < xIndex + platformWidth; x++)
                {
                    if (x < MapWidth)
                    {
                        CurrentMap[x, y] = 6;
                    }
                    if(y + 1 < MapHeight && !spawnedItem)
                    {
                        CurrentMap[Random.Range(x, xIndex + platformWidth), y + 1] = 3;
                        spawnedItem = true;
                    }
                    if(spawnEnemy && CurrentMap[x, y+1] == 0 && CurrentMap[x, y] == 6 && !spawnedEnemy)
                    {
                        CurrentMap[Random.Range(x + 1, xIndex + platformWidth - 1), y + 1] = 7;
                        spawnedEnemy = true;
                    }
                }
            }
            xIndex += platformWidth + distanceBetween;
        }
    }

    public void Append()
    {
        EraseAllPlatforms();
        GenerateMap();
        if (renderImmediate)
        {
            Render();
        }
    }

    void EraseAllPlatforms()
    {
        for(int x = 0; x < MapWidth; x++)
        {
            for(int y = yOffset; y < MapHeight; y++)
            {
                CurrentMap[x, y] = 0;
            }
        }
    }
}
