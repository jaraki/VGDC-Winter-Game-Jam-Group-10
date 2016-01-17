using UnityEngine;
using System.Collections;

public class DestoryGeneration : MonoBehaviour {

    public GameObject levelDestoryPoint;

	// Use this for initialization
	void Start () {
        levelDestoryPoint = GameObject.Find("destoryPoint");
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < levelDestoryPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
	
	}
}
