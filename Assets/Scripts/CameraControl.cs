using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Player thePlayer;

    private Vector3 lastPosition;
    private float distanceTravelX;
    private float distanceTravelY;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        lastPosition = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distanceTravelX = thePlayer.transform.position.x - lastPosition.x;
        distanceTravelY = thePlayer.transform.position.y - lastPosition.y;
        transform.position = new Vector3(transform.position.x + distanceTravelX, transform.position.y + distanceTravelY, transform.position.z);
        lastPosition = thePlayer.transform.position;
	
	}
}
