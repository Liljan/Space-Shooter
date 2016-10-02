using UnityEngine;
using System.Collections;

public class BlasterHandler : MonoBehaviour
{
    private LevelHandler lh;

    public GameObject[] cannons;
    public Transform target;

    private int currentCannon = 0;
    public GameObject BlasterBoltPrefab;
    public GameObject MisslePrefab;

    public float fireRate = 1;
    private float coolDownTime;
    private float currentCooldownTime = 0;

    public float blasterSpeed;

    // audio
    //private AudioManager am;
    public AudioSource audioSource;
    public AudioClip SFX_blast;

    // Use this for initialization
    void Start()
    {
        coolDownTime = 1 / fireRate;
        lh = GameObject.FindObjectOfType<LevelHandler>();
        audioSource = GameObject.FindGameObjectWithTag("AudioHandler").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire") && currentCooldownTime <= 0f)
        {
            Fire();
        }
        else if (Input.GetButtonDown("Missiles"))
        {
            Instantiate(MisslePrefab, transform.position, transform.rotation);
        }

        currentCooldownTime -= Time.deltaTime;
    }

    void Fire()
    {
        Vector3 pos = cannons[currentCannon].transform.position;
        pos.z = 0f;
        Vector3 dir = target.position - pos;
        dir.Normalize();
        dir *= blasterSpeed;

        GameObject obj = Instantiate(BlasterBoltPrefab, pos, Quaternion.identity) as GameObject;
        lh.AddFiredShot();
        obj.GetComponent<BlasterBolt>().Init(dir);

        // am.PlaySFX(SFX_blast);
        audioSource.PlayOneShot(SFX_blast);

        currentCooldownTime = coolDownTime;

        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
