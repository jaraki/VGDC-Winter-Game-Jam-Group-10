using UnityEngine;
using System.Collections;

public class TerrainLoader : MonoBehaviour {
    public GameObject[] prefabs;
    public int[,] TerrainMap
    {
        get
        {
            TerrainMap terrainMap = GetComponent<TerrainMap>();
            return terrainMap.Map;
        }
    }

    public void Render()
    {
        for (int y = 0; y < TerrainMap.GetLength(1); y++)
        {
            for (int x = 0; x < TerrainMap.GetLength(0); x++)
            {
                if(TerrainMap[x,y] != 0)
                {
                    GameObject go = (GameObject)Instantiate(prefabs[TerrainMap[x, y]]);
                    go.transform.parent = transform.transform;
                    go.transform.localPosition = new Vector3(x - 33f, y - 9f, 0);
                }
            }
        }
    }
}
