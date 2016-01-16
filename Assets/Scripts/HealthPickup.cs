using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float healthAmount;
	public AudioClip collected;

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
//			PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
//
//			playerHealth.health += healthAmount;
//			playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 100f);
//
//			playerHealth.UpdateHealthBar();

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
