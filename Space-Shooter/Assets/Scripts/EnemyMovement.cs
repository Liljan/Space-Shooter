﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 vel;

    protected Rigidbody2D rb2d;

    // Use this for initialization
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = vel;
    }
}
