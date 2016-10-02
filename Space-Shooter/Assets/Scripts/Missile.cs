﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Transform target;

    public float speed;


    public void Awake()
    {
        //rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        target = FindTarget();
       // rb2d.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 dir = target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90.0f;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }

    }

    private Transform FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // are there any enemies?

        if (enemies.Length == 0)
            return null;

        // find closest enemy
        int idxClosest = 0;
        Vector3 missilePos = this.transform.position;

        for (int i = 0; i < enemies.Length; ++i)
        {
            Vector3 v1 = enemies[idxClosest].transform.position - missilePos;
            Vector3 v2 = enemies[i].transform.position - missilePos;

            if (v2.sqrMagnitude < v1.sqrMagnitude)
            {
                idxClosest = i;
            }
        }

        Debug.Log(enemies[idxClosest]);
        return enemies[idxClosest].transform;
    }
}
