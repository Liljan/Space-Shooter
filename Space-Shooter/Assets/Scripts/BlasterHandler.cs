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

    public float fireRate = 1.0f;
    private float coolDownTime;
    private float currentCooldownTime = 0.0f;

    public float maxOverheatTime = 1.0f;
    public float overheatFactor = 6.0f;
    private float currentOverheatTime = 0.0f;
    private bool isOverheating = false;

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

        lh.InitOverheat(maxOverheatTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire") && currentCooldownTime <= 0f && currentOverheatTime < maxOverheatTime && !isOverheating)
        {
            Fire();
            currentOverheatTime += Time.deltaTime*overheatFactor;
            lh.SetPlayerOverheat(currentOverheatTime);
        }
        else if (Input.GetButtonDown("Missiles"))
        {
            Instantiate(MisslePrefab, transform.position, transform.rotation);
        }

        currentCooldownTime -= Time.deltaTime;
        UpdateOverheat();
    }

    private void UpdateOverheat()
    {
        if (!isOverheating && currentOverheatTime < maxOverheatTime)
        {
            currentOverheatTime -= Time.deltaTime;
            currentOverheatTime = Mathf.Max(currentOverheatTime, 0.0f);
            lh.SetPlayerOverheat(currentOverheatTime);
        }
        if (currentOverheatTime >= maxOverheatTime && !isOverheating)
        {
            StartCoroutine(Overheat(1.0f));
        }

    }

    public IEnumerator Overheat(float t)
    {
        isOverheating = true;
        yield return new WaitForSeconds(t);
        isOverheating = false;
        currentOverheatTime = 0.0f;
        lh.SetPlayerOverheat(currentOverheatTime);
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

    public void AddFireRate(float f)
    {
        fireRate += f;
        coolDownTime = 1 / fireRate;
    }
}
