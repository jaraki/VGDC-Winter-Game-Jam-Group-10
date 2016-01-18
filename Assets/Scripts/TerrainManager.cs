using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
    public Transform prev;
    public Transform terrain;
    public Transform next;
    public GameObject terrainPrefab;

    private CaveGenerator prevCaveGenerator;
    //private HillGenerator prevHillGenerator;
    private PlatformGenerator prevPlatformGenerator;
    private CaveGenerator caveGenerator;
    //private HillGenerator hillGenerator;
    private PlatformGenerator platformGenerator;
    private CaveGenerator nextCaveGenerator;
    //private HillGenerator nextHillGenerator;
    private PlatformGenerator nextPlatformGenerator;

    // Use this for initialization
    void Start () {
        //getting components
        if(prev)
        {
            prevCaveGenerator = prev.GetComponent<CaveGenerator>();
            //prevHillGenerator = prev.GetComponent<HillGenerator>();
            prevPlatformGenerator = prev.GetComponent<PlatformGenerator>();
        }
        
        caveGenerator = terrain.GetComponent<CaveGenerator>();
        //hillGenerator = terrain.GetComponent<HillGenerator>();
        platformGenerator = terrain.GetComponent<PlatformGenerator>();
        nextCaveGenerator = next.GetComponent<CaveGenerator>();
        //nextHillGenerator = next.GetComponent<HillGenerator>();
        nextPlatformGenerator = next.GetComponent<PlatformGenerator>();
        GenerateAll();
	}
	
	// Update is called once per frame
	void Update () {

    }

    void GenerateAll()
    {
        if(prev)
        {
            prevCaveGenerator.Generate();
            //prevHillGenerator.Append();
            prevPlatformGenerator.Append();
        }
        if(terrain)
        {
            caveGenerator.Generate();
            //hillGenerator.Append();
            platformGenerator.Append();
        }
        if(next)
        {
            nextCaveGenerator.Generate();
            //nextHillGenerator.Append();
            nextPlatformGenerator.Append();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player passed trigger");
            if(prev)
            {
                Destroy(prev.gameObject);
            }
            prev = terrain;
            terrain = next;
            transform.position += new Vector3(36f, 0f, 0f);
            GameObject nextGO = (GameObject)Instantiate(terrainPrefab, transform.position, Quaternion.identity);
            next = nextGO.transform;
            nextCaveGenerator = next.GetComponent<CaveGenerator>();
            //nextHillGenerator = next.GetComponent<HillGenerator>();
            nextPlatformGenerator = next.GetComponent<PlatformGenerator>();
            nextCaveGenerator.Generate();
            nextPlatformGenerator.Append();
        }
    }
}
