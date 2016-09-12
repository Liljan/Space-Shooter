using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Globals : Singleton<Globals>
{
    protected Globals() { } // Protect the constructor!

    private bool paused = false;

    private int score = 0;
    private int scoreMult = 1;

    private float playerHealth;

    private Text scoreText;

    // shots
    private int shotsFired = 0;

    void Awake()
    {
        Debug.Log("Awoke Singleton Instance: " + gameObject.GetInstanceID());
        scoreText = GameObject.FindGameObjectWithTag("DebugStatistics").GetComponent<Text>();
        DisplayScoreText();
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

    public float GetPlayerHealth() { return playerHealth; }
    public void SetPlayerHealth(float f) { playerHealth = f; }

    public int GetShotsFired() { return shotsFired; }
    public void AddFiredShot() { ++shotsFired; }

    public int GetScore() { return score; }
    public void AddScore(int s)
    {
        score += s * scoreMult;
        DisplayScoreText();
    }

    public void DisplayScoreText() { scoreText.text = "Score: " + score; }
}
