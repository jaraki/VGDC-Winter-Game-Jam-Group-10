using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour {

	public float manaAmount;
	public AudioClip collected;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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
