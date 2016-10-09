using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Vector3 velocity;
	
	void Update () {
        transform.position += velocity * Time.deltaTime;
	}
}
