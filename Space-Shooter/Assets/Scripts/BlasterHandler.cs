using UnityEngine;
using System.Collections;

public class BlasterHandler : MonoBehaviour
{

    public GameObject[] cannons;
    private int currentCannon = 0;
    public GameObject BlasterBoltPrefab;

    public float coolDownTime, fireRate;
    private float currentCooldownTime = 0;

    public Vector3 blasterVelocity;
    public float blasterRotation;

    // Use this for initialization
    void Start()
    {

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
        GameObject obj = Instantiate(BlasterBoltPrefab, pos, Quaternion.identity) as GameObject;
        BlasterBolt bb = obj.GetComponent<BlasterBolt>();

        bb.Init(blasterVelocity, blasterRotation * Mathf.Deg2Rad);

        currentCooldownTime = coolDownTime;

        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
