using UnityEngine;
using System.Collections;

public class FlipAndFlop : MonoBehaviour {

	void Start () {
        float xScale,yScale;

        xScale = Random.value > 0.5f ? 1f : -1f;
        yScale = Random.value > 0.5f ? 1f : -1f;

        transform.localScale = new Vector3(xScale, yScale, 1f);
	}
}
