using UnityEngine;
using System.Collections;

public class BlasterBolt : MonoBehaviour
{
    public Boundary bound;

    public float damage;

    protected Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
    }

    public virtual void Init(Vector3 v)
    {
        rb2d.velocity = v;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bound.yMin || transform.position.y > bound.yMax)
            Kill();
    }

    public float GetDamage() { return damage; }
    public void SetDamage(float d) { damage = d; }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
