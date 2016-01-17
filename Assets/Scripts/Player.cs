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
    public GameObject fireball;

    private GameObject mainBar;
    private Image healthBar;
    private Image manaBar;
    private Image staminaBar;
    private Image timeBar;

    const float barHeight = 20f;
    const float barWidth = 200f;
	// Use this for initialization
	void Start () {
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


    }
	
	// Update is called once per frame
	void Update () {
        currentTime -= Time.deltaTime;

        // for testing purposes only
        if (Input.GetKeyDown(KeyCode.E))
        {
            changeHealth(-10f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            changeMana(-10f);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            changeStamina(-10f);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            changeTime(10f);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currentMana >= 10f)
            {
                Instantiate(fireball, transform.transform.position, Quaternion.identity);
                changeMana(-10f);
            }
            
        }
        normalizeValues();
        setBars();
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
    }

    public bool isDead()
    {
        return currentTime == 0 || currentHealth == 0;
    }

}
