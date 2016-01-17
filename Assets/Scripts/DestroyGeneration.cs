using UnityEngine;
using System.Collections;

public class DestroyGeneration : MonoBehaviour {

    private GameObject levelDestroyPoint;

	// Use this for initialization
	void Start () {
        levelDestroyPoint = GameObject.Find("destroyPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < levelDestroyPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	
	}
}
