using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private int score = 0;
    private int scoreMult = 1;
    private float playerHealth;

    private bool paused = false;
    private int shotsFired = 0;

    public Text scoreText, healthText;

    // Use this for initialization
    void Start()
    {
        DisplayScoreText();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pause"))
        {
            if (!paused)
            {
                SetPaused(true);
            }
            else
            {
                SetPaused(false);
            }
        }

    }

    public bool IsPaused() { return paused; }
    public void SetPaused(bool b)
    {
        paused = b;

        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    // public float GetPlayerHealth() { return playerHealth; }
    public void SetPlayerHealth(float f)
    {
        playerHealth = f;
        DisplayHealthText();
    }

    public int GetShotsFired() { return shotsFired; }
    public void AddFiredShot() { ++shotsFired; }

    // public int GetScore() { return score; }
    public void AddScore(int s)
    {
        score += s * scoreMult;
        DisplayScoreText();
    }

    public void DisplayScoreText() { scoreText.text = "Score: " + score; }
    public void DisplayHealthText() { healthText.text = "Health: " + playerHealth; }
}
