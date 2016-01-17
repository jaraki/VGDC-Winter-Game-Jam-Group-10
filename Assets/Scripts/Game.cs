using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public float currentScore;
    public Text scoreText;
    public Text gameOverText;
    public Player player;

    // singleton
    public static Game instance { get; private set; }
    void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        gameOverText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        updateTexts();
	}

    void updateTexts()
    {
        scoreText.text = "Score: " + currentScore.ToString();
        gameOverText.text = gameOver() ? "Game Over!" : "";
    }

    bool gameOver()
    {
        return player.isDead();
    }
}
