using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
    public Transform prev;
    public Transform terrain;

    private CaveGenerator caveGenerator;
    private HillGenerator hillGenerator;
    private TerrainLoader terrainLoader;
	// Use this for initialization
	void Start () {
        caveGenerator = terrain.GetComponent<CaveGenerator>();
        hillGenerator = terrain.GetComponent<HillGenerator>();
        terrainLoader = terrain.GetComponent<TerrainLoader>();
        caveGenerator.Generate();
        hillGenerator.Append();
        terrainLoader.Render();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player passed trigger");
            Instantiate(terrain, transform.position + new Vector3(35f, 0f, 0f), Quaternion.identity);
            GameObject newTerrainManager = (GameObject)Instantiate(this, transform.position + new Vector3(35f, 0f, 0f), Quaternion.identity);
            newTerrainManager.GetComponent<TerrainManager>().prev = this.transform;
            if(prev)
            {
                Destroy(prev.gameObject);
            }
        }
    }
}
