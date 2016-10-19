using UnityEngine;
using System.Collections;
using System;

public class ScorePickup : Powerup {

    private LevelHandler lh;
    public int score = 200;

    public void Awake()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
    }

    public override void ActivatePowerUp()
    {
        lh.AddScore(score);
    }

    public override string GetPickupMessage()
    {
        return "Bonus score: " + score;
    }
}
