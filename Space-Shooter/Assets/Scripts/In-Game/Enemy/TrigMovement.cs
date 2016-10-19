using UnityEngine;
using System.Collections;

public class TrigMovement : EnemyMovement
{
    public float magnitude;
    private float phase = 0.0f;
    public float angularVelocity;

    void Update()
    {
        Vector3 pos = rb2d.position;
        pos.x = magnitude * Mathf.Cos(phase * Mathf.Deg2Rad);
        rb2d.position = pos;

        Debug.Log(pos);

        phase += Time.deltaTime * angularVelocity;
        Debug.Log(phase);
    }
}
