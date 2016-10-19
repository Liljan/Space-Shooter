using UnityEngine;
using System.Collections;

public class TrigMovement : MonoBehaviour
{
    public float magnitude;
    private float phase = 0.0f;
    public float angularVelocity;

    public Vector2 vel;
    private Rigidbody2D rb2d;
    private float centerX;

    // Use this for initialization
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = vel;
        centerX = rb2d.position.x;
    }

    void Update()
    {
        Vector3 pos = rb2d.position;
        pos.x = centerX + magnitude * Mathf.Cos(phase * Mathf.Deg2Rad);
        rb2d.position = pos;

        Debug.Log(pos);

        phase += Time.deltaTime * angularVelocity;
        Debug.Log(phase);
    }
}
