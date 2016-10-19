using UnityEngine;
using System.Collections;

public class SheildPickup : Powerup
{
    private PlayerHealthHandler phh;
    public float sheild = 100.0f;

    public void Awake()
    {
        phh = GameObject.FindObjectOfType<PlayerHealthHandler>();
    }

    public override void ActivatePowerUp()
    {
        phh.AddSheild(sheild);
    }

    public override string GetPickupMessage()
    {
        return "Sheild";
    }
}
