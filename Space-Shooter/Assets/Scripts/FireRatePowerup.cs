using UnityEngine;
using System.Collections;
using System;

public class FireRatePowerup : Powerup
{
    private BlasterHandler bh;
    public float fireRate = 1.0f;

    public void Awake()
    {
        bh = GameObject.FindObjectOfType<BlasterHandler>();
    }

    public override void ActivatePowerUp()
    {
        bh.AddFireRate(fireRate);
    }

    public override string GetPickupMessage()
    {
        return "Fire rate powerup!";
    }
}
