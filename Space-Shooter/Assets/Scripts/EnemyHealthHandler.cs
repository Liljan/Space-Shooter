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

    private SpriteRenderer renderer;

    // Use this for initialization
    void Start()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
        currentHealth = maxHealth;

        renderer = GetComponent<SpriteRenderer>();
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
        else
        {
            StartCoroutine(Blink(0.1f));
        }


    }

    IEnumerator Blink(float time)
    {
        renderer.color = Color.red;
        yield return new WaitForSeconds(time);
        renderer.color = Color.white;
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        GameObject txtObj = Instantiate(displayTextPrefab, transform.position + 2f * Vector3.right, transform.rotation) as GameObject;
        txtObj.GetComponent<TextMesh>().text = score.ToString();

        lh.AddScore(score);
        lh.AddDestroyedEnemy();
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
        else if (col.CompareTag("StopPoint"))
        {
            lh.AddDestroyedEnemy();
            Destroy(this.gameObject, destroyDelay);
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
