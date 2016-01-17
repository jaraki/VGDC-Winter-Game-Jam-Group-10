
using UnityEngine;

public class CaveGenerator : BaseGenerator {
    public int yOffset = 12;

	void FillAll()
    {
        for(int x = 0; x < MapWidth; x++)
        {
            for(int y = 0; y < MapHeight; y++)
            {
                if(y < yOffset)
                {
                    // fill in the map with stone bricks
                    CurrentMap[x, y] = 6;
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
        int xMin = Random.Range(x + 1, x + yOffset / 2);
        int yMin = Random.Range(y + 1, y + yOffset / 2);
        int xMax = Random.Range(x + yOffset / 2 + 1, x + yOffset);
        int yMax = Random.Range(y + yOffset / 2 + 1, y + yOffset);
        for (int dx = xMin; dx < xMax; dx++)
        {
            for (int dy = yMin; dy < yMax; dy++)
            {
                // fill in the map with an empty space
                CurrentMap[dx, dy] = 0;
            }
        }
        // fill in the map with a random item
        CurrentMap[Random.Range(xMin, xMax), Random.Range(yMin, yMax)] = Random.Range(1, 5);
        CurrentMap[Random.Range(xMin, xMax), Random.Range(yMin, yMax)] = Random.Range(1, 5);
    }
}
