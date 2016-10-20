using UnityEngine;
using System.Collections;

public class EnemyHealthHandler : MonoBehaviour
{
    public float maxHealth = 1.0f;
    private float currentHealth;

    public int score = 10;

    public GameObject explosionPrefab;
    public GameObject displayTextPrefab;

    private SpriteRenderer spriteRenderer;
    private Spawnhandler sh;
    private LevelHandler lh;

    // Use this for initialization
    void Start()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
        sh = GameObject.FindObjectOfType<Spawnhandler>();
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
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
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        GameObject txtObj = Instantiate(displayTextPrefab, transform.position + 2f * Vector3.right, Quaternion.identity) as GameObject;
        txtObj.GetComponent<TextMesh>().text = score.ToString();

        lh.AddScore(score);
        sh.RemoveEnemy();
        Destroy(this.gameObject);
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
            sh.RemoveEnemy();
            Destroy(this.gameObject);
        }
        else if (col.CompareTag("Player"))
        {
            Kill();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            PlayerHealthHandler ph = col.gameObject.GetComponent<PlayerHealthHandler>();
            ph.TakeDamage(10f);
        }
    }

    public int GetScore() { return score; }
}
