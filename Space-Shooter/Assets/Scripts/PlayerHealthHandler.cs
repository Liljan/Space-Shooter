using UnityEngine;
using System.Collections;

public class PlayerHealthHandler : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;

    public float maxSheild = 20;
    private float currentSheild;
    public float sheildRefreshRate = 0.5f;

    public float destroyDelay = 0f;

    public GameObject explosionPrefab;

    private LevelHandler lh;

    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        currentSheild = maxSheild;
        lh = GameObject.FindObjectOfType<LevelHandler>();
        lh.InitHealth(maxHealth);
        lh.InitSheild(maxSheild);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentSheild < maxSheild)
        {
            currentSheild += sheildRefreshRate*Time.deltaTime;
            currentSheild = Mathf.Min(currentSheild, maxSheild);
            lh.SetPlayerSheild(currentSheild);

        }
    }

    public void TakeDamage(float d)
    {
        float newSheild = currentSheild - d;
        float healthToRemove = 0.0f;

        if(newSheild < 0.0f)
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
