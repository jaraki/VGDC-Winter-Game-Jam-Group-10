using UnityEngine;
using System.Collections;

public class levelGeneration : MonoBehaviour {

    public GameObject theLevel;
    public Transform generationPoint;
    public float distance;

    private float distanceLevel;

	// Use this for initialization
	void Start () {
        distanceLevel = theLevel.GetComponent<BoxCollider2D>().size.x;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + distanceLevel + distance, transform.position.y, transform.position.z);

            Instantiate(theLevel, transform.position, transform.rotation);
        }

	
	}
}
