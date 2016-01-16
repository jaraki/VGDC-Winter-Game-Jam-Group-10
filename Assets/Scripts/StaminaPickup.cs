using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public float staminaAmount;
	public AudioClip collected;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
//			PlayerStamina playerStamina = other.GetComponent<PlayerStamina>();
//			
//			playerStamina.stamina += staminaAmount;
//			playerStamina.stamina = Mathf.Clamp(playerHealth.stamina, 0f, 100f);
//			
//			playerStamina.UpdateStaminaBar();
			
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
