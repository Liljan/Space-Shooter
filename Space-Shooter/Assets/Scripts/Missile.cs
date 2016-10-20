using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Transform target;
    private Vector3 targetPos;

    public float speed;
    public GameObject explosionPrefab;

    public Boundary borders;

    public void Awake()
    {
        //rb2d = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        target = FindTarget();
        targetPos = Vector3.up * 9000.0f;
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
        else
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

        CheckBoundaries();
    }

    private void CheckBoundaries()
    {
        Vector2 pos = transform.position;
        if (pos.x < borders.xMin || pos.x > borders.xMax || pos.y < borders.yMin || pos.y > borders.yMax)
            Destroy(gameObject);
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

        // Debug.Log(enemies[idxClosest]);
        return enemies[idxClosest].transform;


        // find the most powerful enemy
        /*
        int ind = 0;
        for (int i = 0; i < enemies.Length; ++i)
        {
            int score1 = enemies[i].GetComponent<EnemyHealthHandler>().GetScore();
            int score2 = enemies[ind].GetComponent<EnemyHealthHandler>().GetScore();

            if (score1 > score2)
                ind = i;
        }
        return enemies[ind].transform;

        */
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
