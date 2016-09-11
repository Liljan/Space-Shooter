using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float tilt;

    private Rigidbody2D rb2d;
    private float moveH, moveV;
    private Vector3 movement;

    public Boundary boundary;

    // Use this for initialization
    void Start()
    {
        rb2d = GameObject.FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        movement = new Vector3(moveH, moveV);
        rb2d.velocity = movement * speed;

        rb2d.position = new Vector3(
            Mathf.Clamp(rb2d.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb2d.position.y, boundary.yMin, boundary.yMax));

        transform.rotation = Quaternion.Euler(0f, rb2d.velocity.normalized.x * -tilt, 0f);
    }
}
