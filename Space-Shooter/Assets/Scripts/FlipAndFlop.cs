using UnityEngine;
using System.Collections;

public class FlipAndFlop : MonoBehaviour
{
    void Start()
    { 
        float osx, osy;
        float xScale, yScale;

        // original scale x, y
        osx = transform.localScale.x;
        osy = transform.localScale.y;

        xScale = Random.value > 0.5f ? 1f : -1f;
        yScale = Random.value > 0.5f ? 1f : -1f;

        transform.localScale = new Vector3(xScale * osx, yScale * osy, 1f);
    }
}
