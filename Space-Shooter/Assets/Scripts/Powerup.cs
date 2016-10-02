using UnityEngine;
using System.Collections;

public abstract class Powerup : MonoBehaviour {

    public float speed;
    public Boundary borders;
	
	// Update is called once per frame
	void Update () {

        transform.position -= transform.up * Time.deltaTime * speed;
        CheckBoundaries();
	}

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ActivatePowerUp();
            Destroy(gameObject);
        }
    }

    private void CheckBoundaries()
    {
        Vector2 pos = transform.position;
        if (pos.x < borders.xMin || pos.x > borders.xMax || pos.y < borders.yMin || pos.y > borders.yMax)
            Destroy(gameObject);
    }

    public abstract void ActivatePowerUp();
}
