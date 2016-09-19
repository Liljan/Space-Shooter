using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 vel;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = vel;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
