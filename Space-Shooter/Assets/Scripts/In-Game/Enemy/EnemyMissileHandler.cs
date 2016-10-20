using UnityEngine;
using System.Collections;

public class EnemyMissileHandler : MonoBehaviour {

    public GameObject[] cannons;

    private int currentCannon = 0;
    public GameObject MissilePrefab;

    public float maxTimeToFire;
    private float timeToFire;

    public float missileSpeed;

    // audio
    private AudioSource audioSource;
    public AudioClip SFX_missile;

    // Use this for initialization
    void Start()
    {
        // audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource = GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioSource>();
        timeToFire = Random.Range(1f, maxTimeToFire);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToFire <= 0.0f)
        {
            Fire();
            Fire();

            timeToFire = Random.Range(1f, maxTimeToFire);
        }

        timeToFire -= Time.deltaTime;

    }

    void Fire()
    {
        Vector3 pos = cannons[currentCannon].transform.position;

        GameObject obj = Instantiate(MissilePrefab, pos, Quaternion.identity) as GameObject;
        obj.GetComponent<EnemyMissile>().Init(new Vector3(0.0f, -missileSpeed, 0.0f));

        audioSource.PlayOneShot(SFX_missile);

        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
