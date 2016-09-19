using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnHandler : MonoBehaviour
{
    // bitmap that stores
    public Texture2D levelData;
    private int width, height;
    private int x, y;

    public int cols = 20;
    private int stepSize;

    public Transform startPoint, stopPoint;

    public float stepTime = 1f;
    private float timeSinceLastStep = 0;

    public ObjectByColor[] objectsByColor;

    // Use this for initialization
    void Start()
    {
        width = levelData.width;
        height = levelData.height;

        stepSize = width / cols;
        x = y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastStep >= stepTime)
            Step();

        timeSinceLastStep += Time.deltaTime;
    }

    void Step()
    {

    }


    GameObject FindObjectByColor(Color color)
    {
        foreach (ObjectByColor entry in objectsByColor)
            if (color == entry.c)
                return entry.obj;
        // else
        return null;
    }
}
