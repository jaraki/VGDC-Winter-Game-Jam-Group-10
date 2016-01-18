using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	private Rigidbody2D rb;
	public float teleportY;
	public float teleportX;
	public float gravityConstant;

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Player"))
		{
			rb = col.gameObject.GetComponent<Rigidbody2D>();

			rb.MovePosition (new Vector2(rb.position.x + teleportX, rb.position.y + teleportY));
			rb.velocity = (new Vector2(rb.velocity.x, gravityConstant)); 
		}
	}

	// Use this for initialization
	void Start () {
		teleportX = 1f;
		teleportY = 12f;
		gravityConstant = 10f;
	}

	// Update is called once per frame
	void Update () {

	}
}
