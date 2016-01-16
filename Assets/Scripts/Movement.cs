using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {


	public float speed = 20f;
	public float lift = 100f;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatisGround;
	private bool grounded;

	private Rigidbody2D rb;
	private BoxCollider2D bc;


	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D>();
		groundCheckRadius = 0.1f;
		groundCheck = GetComponent<Transform>();
	}

	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatisGround);
	}

	// Update is called once per frame
	void Update () 
	{
		float moveX = Input.GetAxis ("Horizontal");

		if (Input.GetKeyDown ("space")) {	
			rb.velocity = new Vector2 (moveX * speed, lift);	
		}
			
		rb.velocity = new Vector2 (moveX * speed, rb.velocity.y);
	}
}
