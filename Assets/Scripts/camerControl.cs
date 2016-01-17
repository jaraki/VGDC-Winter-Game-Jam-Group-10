using UnityEngine;
using System.Collections;

public class camerControl : MonoBehaviour {
    public Player thePlayer;

    private Vector3 lastPoisition;
    private float distanceTravelX;
    private float distanceTravelY;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        lastPoisition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distanceTravelX = thePlayer.transform.position.x - lastPoisition.x;
        distanceTravelY = thePlayer.transform.position.y - lastPoisition.y;
        transform.position = new Vector3(transform.position.x + distanceTravelX, transform.position.y + distanceTravelY, transform.position.z);
        lastPoisition = thePlayer.transform.position;
	
	}
}
