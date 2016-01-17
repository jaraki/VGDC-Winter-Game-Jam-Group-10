using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public float speed;
	public float lift;
	bool grounded;

	private Rigidbody2D rb;

	void Start () {

		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () 
	{

		if (rb.velocity.y == 0) 
		{
			grounded = true;
		}
		else 
		{
			grounded = false;
		}

		float moveX = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown ("space") && grounded) 
		{	
			rb.velocity = new Vector2 (moveX * speed, lift);	
		}
		else if(!grounded) 
		{	
			rb.velocity = new Vector2 (moveX * speed * 0.5f, rb.velocity.y);
		} 
		else 
		{
			rb.velocity = new Vector2 ((moveX * speed), rb.velocity.y);
		}
	}
}