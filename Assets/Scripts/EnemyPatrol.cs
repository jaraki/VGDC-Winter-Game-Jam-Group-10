using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {

    private Animator animator;
    public GameObject pat1;
    public GameObject pat2;
    public GameObject enemy;
    public Vector2 start;
    public float distance;
    public float step;
    public float speed;
    public bool moving;
    public bool towards1;
    // Use this for initialization
    void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!moving)
        {
            moving = true;
            if (towards1)
            {
                start = enemy.transform.position;
                distance = Vector2.Distance(pat1.transform.position, start);
                step = distance / speed;
                animator.SetInteger("Direction", 1);
            }
            else
            {
                start = enemy.transform.position;
                distance = Vector2.Distance(pat2.transform.position, start);
                step = distance / speed;
                animator.SetInteger("Direction", 2);
            }
        }

        if (moving)
        {
            if (towards1 && Vector2.Distance(pat1.transform.position, enemy.transform.position) >.1)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, pat1.transform.position, step);
            }
            else if (!towards1 && Vector2.Distance(pat2.transform.position, enemy.transform.position) > .1)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, pat2.transform.position, step);
            }
            else if (towards1 && Vector2.Distance(pat1.transform.position, enemy.transform.position) <= .1)
            {
                moving = false;
                towards1 = false;
            }
            else if (!towards1 && Vector2.Distance(pat2.transform.position, enemy.transform.position) <= .1)
            {
                moving = false;
                towards1 = true;
            }
        }
    }
}
