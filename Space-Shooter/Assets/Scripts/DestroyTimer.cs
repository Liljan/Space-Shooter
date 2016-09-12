using UnityEngine;
using System.Collections;

public class DestroyTimer : MonoBehaviour {

    public float timer = 2f;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, timer);
    }
}
