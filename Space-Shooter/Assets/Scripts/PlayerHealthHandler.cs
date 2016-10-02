using UnityEngine;
using System.Collections;

public class PlayerHealthHandler : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public float destroyDelay = 0f;

    public GameObject explosionPrefab;

    private LevelHandler lh;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        lh = GameObject.FindObjectOfType<LevelHandler>();
        lh.InitHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float d)
    {
        currentHealth -= d;

        currentHealth = Mathf.Max(currentHealth, 0f);
        lh.SetPlayerHealth(currentHealth);
        if (currentHealth == 0f)
        {
            Kill();
        }
    }

    public void AddHealth(float d)
    {
        currentHealth += d;
        currentHealth = Mathf.Max(currentHealth, maxHealth);
        lh.SetPlayerHealth(currentHealth);
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject, destroyDelay);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyBlaster"))
        {
            BlasterBolt bb = col.gameObject.GetComponent<BlasterBolt>();
            if (bb)
            {
                TakeDamage(bb.GetDamage());
                bb.Kill();
            }
        }
    }

}
