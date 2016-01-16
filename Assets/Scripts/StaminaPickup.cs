using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float staminaAmount;
	public AudioClip collected;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {			
			Destroy(transform.root.gameObject); 
			
		}
		
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
