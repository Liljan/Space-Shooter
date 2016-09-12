﻿using UnityEngine;
using System.Collections;

public class PlayerHealthHandler : MonoBehaviour
{
    public float maxHealth = 1;
    private float currentHealth;

    public float destroyDelay = 0f;

    public GameObject explosionPrefab;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float d)
    {
        currentHealth -= d;
        if (currentHealth <= 0f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject, destroyDelay);
    }
}
