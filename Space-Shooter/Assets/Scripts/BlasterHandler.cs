using UnityEngine;
using System.Collections;

public class BlasterHandler : MonoBehaviour
{

    public GameObject[] cannons;
    private int currentCannon = 0;
    public GameObject BlasterBoltPrefab;

    public float coolDownTime, fireRate;
    private float currentCooldownTime = 0;

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
        Instantiate(BlasterBoltPrefab, pos, Quaternion.identity);

        currentCooldownTime = coolDownTime;

        ++currentCannon;
        if (currentCannon > cannons.Length - 1)
            currentCannon = 0;
    }
}
