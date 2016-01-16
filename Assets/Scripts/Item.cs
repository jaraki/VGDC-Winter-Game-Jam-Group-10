using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public string type;
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        tag = type;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
