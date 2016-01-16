using UnityEngine;
using System.Collections;

public class TimeObject : MonoBehaviour {


	public float timeAmount;
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
