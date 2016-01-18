﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public float maxHealth;
    public float currentHealth;
    public float maxMana;
    public float currentMana;
    public float maxStamina;
    public float currentStamina;
    public float maxTime;
    public float currentTime;
    public float currentSpeed;
    public float maxSpeed;
    public float lift;
    public float currentCastTime;
    public float maxCastTime = 2.0f;
    public float currentDigTime;
    public float maxDigTime;
    public GameObject dust;
    public GameObject fireball;
    public GameObject floor;
    public GameObject ceiling;
    public GameObject leftSide;
    public GameObject rightSide;
    public BoxCollider2D top;
    public BoxCollider2D bottom;
    public BoxCollider2D left;
    public BoxCollider2D right;
    public float counter;
    public float maxCounter = 1.5f;

    private GameObject mainBar;
    private Image healthBar;
    private Image manaBar;
    private Image staminaBar;
    private Image timeBar;

    private Vector3 screenPoint;
    private Image castBar;

    private bool grounded;
	private bool bouncing;
    private bool canMove;
    private bool isCasting;
    private bool isDigging;
    private Rigidbody2D rb;

    private float invulnTimer;

    // sprite orientation variables
    private Transform model;
    private float flipX;
    private float modelPosX;
    private bool isFlipped; // false when facing right; true when facing left

    const float barHeight = 20f;
    const float barWidth = 200f;
	// Use this for initialization
	void Start () {
        isCasting = false;
        canMove = true;
        isDigging = false;

        // getting components
        rb = GetComponent<Rigidbody2D>();

        // sprite flipping
        model = transform.Find("Sprite");
        flipX = model.localScale.x;
        modelPosX = model.localPosition.x;

        // main bar
        mainBar = new GameObject(gameObject.name + " bars");
        mainBar.transform.parent = GameObject.Find("Canvas").transform;
        mainBar.transform.SetAsFirstSibling();

        // health bar
        GameObject healthGO = new GameObject(gameObject.name + " health bar");
        healthGO.transform.parent = mainBar.transform;
        healthBar = healthGO.AddComponent<Image>();
        healthBar.color = Color.green;
        healthBar.rectTransform.pivot = Vector2.zero;

        // mana bar
        GameObject manaGO = new GameObject(gameObject.name + " mana bar");
        manaGO.transform.parent = mainBar.transform;
        manaBar = manaGO.AddComponent<Image>();
        manaBar.color = Color.blue;
        manaBar.rectTransform.pivot = Vector2.zero;
        manaBar.rectTransform.sizeDelta = new Vector2(100f, 20f);

        // stamina bar
        GameObject staminaGO = new GameObject(gameObject.name + " stamina bar");
        staminaGO.transform.parent = mainBar.transform;
        staminaBar = staminaGO.AddComponent<Image>();
        staminaBar.color = Color.red;
        staminaBar.rectTransform.pivot = Vector2.zero;
        staminaBar.rectTransform.sizeDelta = new Vector2(200f, 20f);

        // time bar
        GameObject timeGO = new GameObject(gameObject.name + " time bar");
        timeGO.transform.parent = mainBar.transform;
        timeBar = timeGO.AddComponent<Image>();
        timeBar.color = Color.yellow;
        timeBar.rectTransform.pivot = Vector2.zero;
        timeBar.rectTransform.sizeDelta = new Vector2(300f, 20f);

        // cast bar
        GameObject castGO = new GameObject(gameObject.name + " cast bar");
        castGO.transform.parent = mainBar.transform;
        castBar = castGO.AddComponent<Image>();
        castBar.color = Color.grey;
        castBar.rectTransform.pivot = Vector2.zero;
        castBar.rectTransform.sizeDelta = new Vector2(100f, 20f);
    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;
        invulnTimer -= Time.deltaTime;
        castTimeDig();
        castFireball();
        handleVelocityAndOrientation();
        normalizeValues();
        setBars();
    }
    void castTimeDig()
    {
        if (isDigging)
        {
            currentDigTime += Time.deltaTime;
        }
        if (currentDigTime >= maxDigTime)
        {
            currentDigTime = 0f;
            canMove = true;
            isDigging = false;
        }
    }
    void castFireball()
    {
        if (isCasting)
        {
            currentCastTime += Time.deltaTime;
        }

        if (currentCastTime >= maxCastTime)
        {
            currentCastTime = 0f;
            canMove = true;
            isCasting = false;
            int dir = isFlipped ? -1 : 1;
            Vector3 offset = dir * Vector3.right;
            Instantiate(fireball, transform.transform.position + offset, Quaternion.identity);
            fireball.GetComponent<Fireball>().isFlipped = isFlipped;
            changeMana(-10f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentMana >= 10f)
            {
                isCasting = true;
                canMove = false;
            }
        }
    }
    void setBars()
    {
        float offset = 1.5f * barHeight;
        healthBar.rectTransform.anchoredPosition = new Vector3(0f, Screen.height - 1f * offset, 0f);
        healthBar.rectTransform.sizeDelta = new Vector2(currentHealth / maxHealth * barWidth, barHeight);
        manaBar.rectTransform.anchoredPosition = new Vector3(0f, Screen.height - 2f * offset, 0f);
        manaBar.rectTransform.sizeDelta = new Vector2(currentMana / maxMana * barWidth, barHeight);
        staminaBar.rectTransform.anchoredPosition = new Vector3(0f, Screen.height - 3f * offset, 0f);
        staminaBar.rectTransform.sizeDelta = new Vector2(currentStamina / maxStamina * barWidth, barHeight);
        timeBar.rectTransform.anchoredPosition = new Vector3(0f, Screen.height - 4f * offset, 0f);
        timeBar.rectTransform.sizeDelta = new Vector2(currentTime / maxTime * barWidth, barHeight);

        if (isCasting || isDigging)
        {
            castBar.enabled = true;
            screenPoint = Camera.main.WorldToScreenPoint(transform.transform.position);
            screenPoint.x -= 50f;
            screenPoint.y -= 200f / Camera.main.orthographicSize;
            castBar.rectTransform.anchoredPosition = screenPoint;
            if (isDigging)
            {
                castBar.rectTransform.sizeDelta = new Vector2(0.5f * currentDigTime / maxDigTime * barWidth, 0.5f * barHeight);
            }
            else
            {
                castBar.rectTransform.sizeDelta = new Vector2(0.5f * currentCastTime / maxCastTime * barWidth, 0.5f * barHeight);
            }
        }
        else
        {
            castBar.enabled = false;
        }
    }
    void handleVelocityAndOrientation()
    {
        if(canMove)
        {
			if (floor != null) 
			{
				grounded = true;
				bouncing = false;
			} 
			else if (leftSide != null && floor == null) 
			{
				grounded = false;
				bouncing = true;

				rb.MovePosition(new Vector2(rb.position.x - 0.1f, rb.position.y));
			} 
			else if (rightSide != null && floor == null) 
			{
				grounded = false;
				bouncing = true;

				rb.MovePosition(new Vector2(rb.position.x + 0.1f, rb.position.y));
			} 
			else if (floor == null) 
			{
				grounded = false;
			}

            float moveX = Input.GetAxis("Horizontal");
            float moveDown = Input.GetAxis("Vertical");
            if (moveDown < 0 && floor != null && floor.CompareTag("Dirt"))
            {
                Vector2 temp = floor.transform.position;
                Quaternion tempq = floor.transform.rotation;
                Instantiate(dust, temp, tempq);
                Destroy(floor, maxDigTime);
                canMove = false;
                isDigging = true;
                floor = null;
            }
            else if (moveDown > 0 && ceiling != null && ceiling.CompareTag("Dirt"))
            {
                Vector2 temp = ceiling.transform.position;
                Quaternion tempq = ceiling.transform.rotation;
                Instantiate(dust, temp, tempq);
                Destroy(ceiling, maxDigTime);
                canMove = false;
                isDigging = true;
                ceiling = null;
            }
            else if (moveX > 0 && leftSide != null && leftSide.CompareTag("Dirt"))
            {
                Vector2 temp = leftSide.transform.position;
                Quaternion tempq = leftSide.transform.rotation;
                Instantiate(dust, temp, tempq);
                Destroy(leftSide, maxDigTime);
                canMove = false;
                isDigging = true;
            }
            else if (moveX < 0 && rightSide != null && rightSide.CompareTag("Dirt"))
            {
                Vector2 temp = rightSide.transform.position;
                Quaternion tempq = rightSide.transform.rotation;
                Instantiate(dust, temp, tempq);
                Destroy(rightSide, maxDigTime);
                canMove = false;
                isDigging = true;
            }

			if (Input.GetKeyDown ("space") && grounded) 
			{
				rb.velocity = new Vector2 (moveX * currentSpeed, lift);
			} 
			else if (bouncing) 
			{
				rb.AddForce(new Vector2 (-0.5f * rb.velocity.x, -0.5f * rb.velocity.y));
			} 
			else if (!grounded) 
			{
				rb.velocity = new Vector2 (moveX * currentSpeed * 0.5f, rb.velocity.y);
			}
			else
			{			
				rb.velocity = new Vector2((moveX * currentSpeed), rb.velocity.y);
			}
				
            if (rb.velocity.x < 0f && !isFlipped || rb.velocity.x > 0f && isFlipped)
            {
                isFlipped = !isFlipped;
            }
            int flip = isFlipped ? 1 : -1;
            model.localScale = new Vector3(flipX * flip, model.localScale.y, model.localScale.z);
            model.localPosition = new Vector3(modelPosX * flip, model.localPosition.y, model.localPosition.z);
            currentStamina += flip * rb.velocity.x * 0.01f;
            currentSpeed = (currentStamina / maxStamina) * maxSpeed + 5f;
        }
        
        
    }

    void normalizeValues()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        if (currentTime > maxTime)
        {
            currentTime = maxTime;
        }
        if (currentHealth < 0f)
        {
            currentHealth = 0f;
        }
        if (currentMana < 0f)
        {
            currentMana = 0f;
        }
        if (currentStamina < 0f)
        {
            currentStamina = 0f;
        }
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }
    }

    void changeHealth(float delta)
    {
        // changes the player health by the delta
        // use negative value for damage, positive value for heal
        currentHealth += delta;
    }

    void changeMana(float delta)
    {
        // changes the player mana by the delta
        // use negative value for decrease, positive value for increase
        currentMana += delta;
    }

    void changeStamina(float delta)
    {
        // changes the player health by the delta
        // use negative value for decrease, positive value for increase
        currentStamina += delta;
    }

    void changeTime(float delta)
    {
        // changes the player time by the delta
        // use negative value for decrease, positive value for increase
        currentTime += delta;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Health"))
        {
            Game.instance.currentScore++;
            changeHealth(10f);
        }
        else if (col.gameObject.CompareTag("Mana"))
        {
            Game.instance.currentScore++;
            changeMana(10f);
        }
        else if (col.gameObject.CompareTag("Stamina"))
        {
            Game.instance.currentScore++;
            changeStamina(10f);
        }
        else if (col.gameObject.CompareTag("Time"))
        {
            Game.instance.currentScore++;
            changeTime(10f);
        }
        else if (col.gameObject.CompareTag("Enemy"))
        {
            if (invulnTimer > 0f)
            {
                return;
            }
            changeHealth(-10f);
            invulnTimer = 2f;
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        Collider2D collider = col.contacts[0].otherCollider;
    
        if (collider == top)
        {
            ceiling = col.gameObject;
        }
        else if (collider == bottom)
        {
            floor = col.gameObject;
        }
        else if (collider == left)
        {
            leftSide = col.gameObject;
        }
        else if (collider == right)
        {
            rightSide = col.gameObject;

        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Collider2D collider = col.contacts[0].otherCollider;
        if (collider == top)
        {
            ceiling = null;
        }
        else if (collider == bottom)
        {
            floor = null;
        }
        else if (collider == left)
        {
            leftSide = null;
        }
        else if (collider == right)
        {
            rightSide = null;

        }
    }

    public bool isDead()
    {
        return currentTime == 0 || currentHealth == 0;
    }

}
