using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
    public Rigidbody2D rb;
    public bool isFlipped;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        int flip = isFlipped ? -1 : 1;
        rb.velocity = new Vector2(10f, 0f) * flip;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
