using UnityEngine;
using System.Collections;

public class ScorePickup : Powerup {

    private LevelHandler lh;
    public int score = 200;
    public GameObject scorePrefab;

    public void Awake()
    {
        lh = GameObject.FindObjectOfType<LevelHandler>();
    }

    public override void ActivatePowerUp()
    {
        lh.AddScore(score);

        GameObject txtObj = Instantiate(scorePrefab, transform.position, transform.rotation) as GameObject;
        txtObj.GetComponent<TextMesh>().text = score.ToString();
    }
}
