using UnityEngine;
using System.Collections;

public class EnemyMissile : BlasterBolt
{
    public override void Init(Vector3 v)
    {
        Debug.Log("Hellos");
        float oldMag = v.magnitude;

        try
        {
            Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            v = playerPos - transform.position;
            v.Normalize();
            v *= oldMag;
        }
        catch (System.Exception)
        {
            throw;
        }

        rb2d.velocity = v;
    }
}
