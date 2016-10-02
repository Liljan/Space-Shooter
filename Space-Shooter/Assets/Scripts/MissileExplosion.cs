using UnityEngine;
using System.Collections;

public class MissileExplosion : MonoBehaviour {

    public float damage = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            EnemyHealthHandler enemy = col.gameObject.GetComponent<EnemyHealthHandler>();
            enemy.TakeDamage(damage);
        }
    }


}
