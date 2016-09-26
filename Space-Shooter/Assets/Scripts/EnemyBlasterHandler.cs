using UnityEngine;
using System.Collections;

public class EnemyBlasterHandler : MonoBehaviour
{
    public GameObject[] cannons;

    private int currentCannon = 0;
    public GameObject BlasterBoltPrefab;

    public float fireRate = 1;
    private float timeToFire;

    public float blasterSpeed;

    // audio
    private AudioManager am;
    public AudioClip SFX_blast;


    // Use this for initialization
    void Start()
    {
        timeToFire = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFire <= 0.0f)
        {
            Fire();
            Fire();

            timeToFire = Random.Range(5f, 10f);
        }

        timeToFire -= Time.deltaTime;

    }

    void Fire()
    {
        Vector3 pos = cannons[currentCannon].transform.position;

        GameObject obj = Instantiate(BlasterBoltPrefab, pos, Quaternion.identity) as GameObject;
        obj.GetComponent<BlasterBolt>().Init(new Vector3(0.0f, -blasterSpeed, 0.0f));

        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
