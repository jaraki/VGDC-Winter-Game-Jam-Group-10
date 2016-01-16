using UnityEngine;
using System.Collections;

public class Time : MonoBehaviour {


	public float timeAmount;
	public AudioClip collected;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
//			PlayerTime playerTime = other.GetComponent<PlayerTime>();
//			
//			playerTime.time += timeAmount;
//			playerTime.time = Mathf.Clamp(playerTime.time, 0f, 100f);
//			
//			playerTime.UpdateTimeBar();
			
			Destroy(transform.root.gameObject); 
			
		}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
