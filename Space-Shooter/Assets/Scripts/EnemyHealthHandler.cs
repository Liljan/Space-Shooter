using UnityEngine;
using System.Collections;

public class EnemyHealthHandler : MonoBehaviour
{
    private LevelHandler lh;
    public float maxHealth = 1;
    private float currentHealth;

    public float destroyDelay = 0f;

    public int score = 10;

    public GameObject explosionPrefab;
    public GameObject displayTextPrefab;

    // Use this for initialization
    void Start()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float d)
    {
        currentHealth -= d;
        if (currentHealth <= 0f)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        GameObject txtObj = Instantiate(displayTextPrefab, transform.position + 2f * Vector3.right, transform.rotation) as GameObject;
        txtObj.GetComponent<TextMesh>().text = score.ToString();

        lh.AddScore(score);
        Destroy(this.gameObject, destroyDelay);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PlayerBlaster"))
        {
            BlasterBolt bb = col.gameObject.GetComponent<BlasterBolt>();
            if (bb)
            {
                TakeDamage(bb.GetDamage());
                bb.Kill();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            PlayerHealthHandler ph = col.gameObject.GetComponent<PlayerHealthHandler>();
            ph.TakeDamage(10f);
        }

        Kill();
    }
}
