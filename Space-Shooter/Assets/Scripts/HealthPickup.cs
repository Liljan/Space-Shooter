using UnityEngine;
using System.Collections;
using System;

public class HealthPickup : Powerup
{
    private PlayerHealthHandler phh;
    public float health = 20.0f;
       
    public void Awake()
    {
        phh = GameObject.FindObjectOfType<PlayerHealthHandler>();
    }

    public override void ActivatePowerUp()
    {
        phh.AddHealth(health);
    }
}
