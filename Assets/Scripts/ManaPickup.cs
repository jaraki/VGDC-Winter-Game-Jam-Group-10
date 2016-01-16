using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour {

	public float manaAmount;
	public AudioClip collected;
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
//			PlayerMana playerMana = other.GetComponent<PlayerMana>();
//			
//			playerMana.mana += playerMana;
//			playerMana.mana = Mathf.Clamp(playerMana.mana, 0f, 100f);
//			
//			playerMana.UpdateManaBar();
			
			Destroy(transform.root.gameObject); 
			
		}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
