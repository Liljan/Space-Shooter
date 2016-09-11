using UnityEngine;
using System.Collections;

public class BlasterBolt : MonoBehaviour
{
    public Vector3 vel;
    public Boundary bound;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel;

        if (transform.position.y < bound.yMin || transform.position.y > bound.yMax)
            Destroy(this.gameObject);
    }
}
