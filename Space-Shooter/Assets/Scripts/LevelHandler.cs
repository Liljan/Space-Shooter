﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private int score = 0;
    private int scoreMult = 1;
    private float playerHealth, playerMaxHealth;
    private float playerSheild, playerMaxSheild;
    private float playerOverheat, playerMaxOverheat;

    private bool paused = false;
    private int shotsFired = 0;

    // enemies
    private int remainingEnemies;

    public Text scoreText;
    public BarScript healthBar;
    public BarScript sheildBar;
    public BarScript overheatBar;

    public GameObject hintTextObject;
    private Text hintText;

    private Spawnhandler spawnHandler;
    private Countdown messageGUIHandler;

    void Awake()
    {
        spawnHandler = GetComponent<Spawnhandler>();

        messageGUIHandler = GameObject.FindObjectOfType<Countdown>();
        StartCoroutine(StartRound(1.5f));
    }

    IEnumerator StartRound(float dt)
    {
        spawnHandler.enabled = false;
        messageGUIHandler.ShowMessage(dt, "Prepare for incoming enemies.");
        yield return new WaitForSeconds(dt);
        messageGUIHandler.ShowMessage(dt, "May the Force be with you.");
        yield return new WaitForSeconds(dt);
        spawnHandler.enabled = true;
    }

    void Start()
    {
        spawnHandler.enabled = false;
        DisplayScoreText();

        hintText = hintTextObject.GetComponentInChildren<Text>();
        HideHintText();
    }

    void SetHintText(string s)
    {
        hintText.text = s;
    }

    void ShowHintText()
    {
        hintTextObject.SetActive(true);
    }

    void HideHintText()
    {
        hintTextObject.SetActive(false);
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

    public void InitOverheat(float maxOverheat)
    {
        playerMaxOverheat = maxOverheat;
        SetPlayerOverheat(0.0f);
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

    public void SetMaxPlayerHealth(float f)
    {
        playerMaxHealth = f;
        healthBar.UpdateBar(playerHealth, playerMaxHealth);
    }

    public void SetPlayerSheild(float f)
    {
        playerSheild = f;
        sheildBar.UpdateBar(playerSheild, playerMaxSheild);
    }

    public void SetMaxPlayerSheild(float f)
    {
        playerMaxSheild = f;
        sheildBar.UpdateBar(playerSheild, playerMaxSheild);
    }

    public void SetPlayerOverheat(float f)
    {
        playerOverheat = f;
        overheatBar.UpdateBar(playerOverheat, playerMaxOverheat);
    }

    public void SetmaxPlayerOverheat(float f)
    {
        playerMaxOverheat = f;
        sheildBar.UpdateBar(playerOverheat, playerMaxOverheat);
    }

    public int GetShotsFired() { return shotsFired; }
    public void AddFiredShot() { ++shotsFired; }

    // public int GetScore() { return score; }
    public void AddScore(int s)
    {
        score += s * scoreMult;
        DisplayScoreText();
    }

    public void SetRemainingEnemies(int n) { remainingEnemies = n; }
    public int GetRemainingEnemies() { return remainingEnemies; }

    public void DisplayScoreText() { scoreText.text = "Score: " + score; }
    public void DisplayWaveText(int nWaves) { messageGUIHandler.ShowWaveNumber(nWaves); }

    public void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    public IEnumerator WinCoroutine()
    {
        yield return new WaitForSeconds(5);
    }


}
