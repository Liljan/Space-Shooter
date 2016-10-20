using UnityEngine;
using System.Collections;

public class PlayerHealthHandler : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public float maxSheild = 20;
    private float currentSheild;
    public float sheildRefreshRate = 0.5f;

    public GameObject explosionPrefab;

    private LevelHandler lh;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        currentSheild = maxSheild;
        lh.InitHealth(maxHealth);
        lh.InitSheild(maxSheild);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSheild < maxSheild)
        {
            currentSheild += sheildRefreshRate * Time.deltaTime;
            currentSheild = Mathf.Min(currentSheild, maxSheild);
            lh.SetPlayerSheild(currentSheild);
        }
    }

    public void TakeDamage(float d)
    {
        float newSheild = currentSheild - d;
        float healthToRemove = 0.0f;

        if (newSheild > 0.0f)
            StartCoroutine(BlinkCyan(0.1f));
        else
            StartCoroutine(BlinkRed(0.1f));

        if (newSheild < 0.0f)
        {
            healthToRemove = Mathf.Abs(newSheild);
            newSheild = 0.0f;
        }

        currentSheild = newSheild;
        lh.SetPlayerSheild(currentSheild);

        currentHealth -= healthToRemove;

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

    public void AddSheild(float d)
    {
        currentSheild += d;
        currentSheild = Mathf.Max(currentHealth, maxSheild);
        lh.SetPlayerSheild(currentSheild);
    }

    public void Kill()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        lh.Lose();
        Destroy(this.gameObject);
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
        else if (col.CompareTag("Enemy") || col.CompareTag("Asteroid"))
        {
            TakeDamage(20.0f);
        }
    }

    IEnumerator BlinkCyan(float time)
    {
        spriteRenderer.color = Color.cyan;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
    }

    IEnumerator BlinkRed(float time)
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
    }

}
