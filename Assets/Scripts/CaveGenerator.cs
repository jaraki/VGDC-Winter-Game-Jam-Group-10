
using UnityEngine;

public class CaveGenerator : BaseGenerator {
    public int yOffset = 12;
    public float stoneFreq;
    public float enemyFreq;

	void FillAll()
    {
        for(int x = 0; x < MapWidth; x++)
        {
            for(int y = 0; y < MapHeight; y++)
            {
                if(y < yOffset)
                {
                    // fill in the map with stone bricks
                    if(Random.Range(0f, 1f) <= stoneFreq)
                    {
                        CurrentMap[x, y] = 6;
                    }
                    else
                    {
                        CurrentMap[x, y] = 5;
                    }
                    
                }
                else
                {
                    // fill in the map with empty space
                    CurrentMap[x, y] = 0;
                }
            }
        }
    }

    public void GenerateMap()
    {
        for (int x = 0; x < MapWidth; x+=yOffset)
        {
            for (int y = 0; y < yOffset; y+=yOffset)
            {
                CreateCave(x, y);
            }
        }
    }

    public void Generate()
    {
        FillAll();
        GenerateMap();
    }

    public void CreateCave(int x, int y)
    {
        int xMin = Random.Range(x + 1, x + yOffset / 2 - 1);
        int yMin = Random.Range(y + 1, y + yOffset / 2 - 1);
        int xMax = Random.Range(x + yOffset / 2 + 1, x + yOffset);
        int yMax = Random.Range(y + yOffset / 2 + 1, y + yOffset);
        bool spawnEnemy = Random.Range(0f, 1f) < enemyFreq;
        for (int dx = xMin; dx < xMax; dx++)
        {
            for (int dy = yMin; dy < yMax; dy++)
            {
                // fill in the map with an empty space
                CurrentMap[dx, dy] = 0;
            }
        }
        // spawn an enemy if necessary
        if(spawnEnemy)
        {
            CurrentMap[Random.Range(xMin + 1, xMax - 1), yMin] = 7;
            Debug.Log("Enemy spawned");
        }
        // fill in the map with a random item
        int numItems = Random.Range(1, 4);
        for(int i = 0; i < numItems; i ++)
        {
            int itemIndex = Random.Range(1, 5);
            if(itemIndex == 3)
            {
                // make sure that stamina does not spawn in caves
                bool up = Random.Range(0, 2) == 0;
                if(up)
                {
                    itemIndex++;
                }
                else
                {
                    itemIndex--;
                }
            }
            int dx = Random.Range(xMin, xMax);
            int dy = Random.Range(yMin, yMax);
            if(CurrentMap[dx, dy] == 0)
            {
                CurrentMap[dx, dy] = itemIndex;
            }
        }
    }
}
