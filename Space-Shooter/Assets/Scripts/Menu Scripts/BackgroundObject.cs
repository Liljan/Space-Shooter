using UnityEngine;
using System.Collections;

public class BackgroundObject : MonoBehaviour
{
    public Boundary borders;
    public Vector3 velocity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        CheckBoundary();
    }

    public void CheckBoundary()
    {
        Vector2 pos = transform.position;
        if (pos.x < borders.xMin || pos.x > borders.xMax || pos.y < borders.yMin || pos.y > borders.yMax)
            Destroy(gameObject);
    }
}
