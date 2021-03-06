﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public Player thePlayer;

    private Vector3 initialPosition;
    private Vector3 lastPosition;
    private float distanceTravelX;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<Player>();
        lastPosition = thePlayer.transform.position;
        initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distanceTravelX = thePlayer.transform.position.x - lastPosition.x;
        transform.position = new Vector3(transform.position.x + distanceTravelX, transform.position.y, transform.position.z);
        lastPosition = thePlayer.transform.position;
        if(transform.position.y < 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }
        if(transform.position.x < initialPosition.x)
        {
            transform.position = new Vector3(initialPosition.x, transform.position.y, transform.position.z);
        }
	
	}
}
