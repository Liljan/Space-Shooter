using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private int score = 0;
    private int scoreMult = 1;
    private float playerHealth, playerMaxHealth;
    private float playerSheild, playerMaxSheild;

    private bool paused = false;
    private int shotsFired = 0;

    // enemies
    private int remainingEnemies;

    public Text scoreText;
    public BarScript healthBar;
    public BarScript sheildBar;

    private ArcadeSpawnHandler spawnHandler;
    private Countdown waveGUIHandler;


    void Awake()
    {
        spawnHandler = GetComponent<ArcadeSpawnHandler>();
        waveGUIHandler = GameObject.FindObjectOfType<Countdown>();
    }

    // Use this for initialization
    void Start()
    {
        DisplayScoreText();
    }

    public void InitHealth(float maxHealth)
    {
        playerMaxHealth = maxHealth;
        playerHealth = playerMaxHealth;
    }

    public void InitSheild(float maxSheild)
    {
        playerMaxSheild = maxSheild;
        playerSheild = playerMaxSheild;
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

        if (Input.GetButtonDown("Restart"))
        {
            Application.LoadLevel(Application.loadedLevel);
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
        //Debug.Log(playerHealth.ToString());
        healthBar.UpdateBar(playerHealth, playerMaxHealth);
    }

    public void SetPlayerSheild(float f)
    {
        playerSheild = f;
        sheildBar.UpdateBar(playerSheild, playerMaxSheild);
    }

    public int GetShotsFired() { return shotsFired; }
    public void AddFiredShot() { ++shotsFired; }

    // public int GetScore() { return score; }
    public void AddScore(int s)
    {
        score += s * scoreMult;
        DisplayScoreText();
    }

    public void AddDestroyedEnemy()
    {
        --remainingEnemies;

        Debug.Log(remainingEnemies);

        if (remainingEnemies <= 0)
        {
            spawnHandler.NextWave();
        }
    }

    public void SetRemainingEnemies(int n) { remainingEnemies = n; }

    public void DisplayScoreText() { scoreText.text = "Score: " + score; }
    public void DisplayWaveText(int nWaves) { waveGUIHandler.ShowWaveNumber(nWaves); }
}
