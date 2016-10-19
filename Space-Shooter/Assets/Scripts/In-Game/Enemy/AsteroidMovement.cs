using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour
{
    private float rotation = 0.0f;
    public float MAX_ANGULAR_VELOCITY;
    private float angularVelocity;

    public void Start()
    {
        angularVelocity = Random.Range(-MAX_ANGULAR_VELOCITY, MAX_ANGULAR_VELOCITY);
        angularVelocity *= Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, 0.0f, rotation);
        rotation += Time.deltaTime * angularVelocity;
    }
}
