using UnityEngine;
using System.Collections;

public class BlasterHandler : MonoBehaviour
{
    private LevelHandler lh;

    public GameObject[] cannons;
    public Transform target;

    private int currentCannon = 0;
    public GameObject BlasterBoltPrefab;

    public float fireRate = 1;
    private float coolDownTime;
    private float currentCooldownTime = 0;

    public float blasterSpeed;

    // audio
    private AudioManager am;
    public AudioClip SFX_blast;

    // Use this for initialization
    void Start()
    {
        coolDownTime = 1 / fireRate;
        lh = GameObject.FindObjectOfType<LevelHandler>();
        // am = GameObject.FindObjectOfType<AudioManager>();
        am = this.gameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && currentCooldownTime <= 0f)
        {
            Fire();
        }

        currentCooldownTime -= Time.deltaTime;
    }

    void Fire()
    {
        Vector3 pos = cannons[currentCannon].transform.position;
        pos.z = 0f;
        //        Vector3 dir = target.position - pos;
        //        Vector3 newDir = Vector3.RotateTowards(pos,target.position,-10f*Mathf.Deg2Rad,0F);

        GameObject obj = Instantiate(BlasterBoltPrefab, pos, Quaternion.identity) as GameObject;
        lh.AddFiredShot();
        //        obj.GetComponent<BlasterBolt>().Init(newDir);
        obj.GetComponent<BlasterBolt>().Init(new Vector3(0f, blasterSpeed, 0f));

        am.PlaySFX(SFX_blast);

        currentCooldownTime = coolDownTime;



        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
