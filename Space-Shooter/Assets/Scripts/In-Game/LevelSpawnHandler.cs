using UnityEngine;
using System.Collections;
using System;

public class LevelSpawnHandler : Spawnhandler
{
    public Texture2D levelData;
    private int levelWidth, levelHeight;

    public ObjectByColor[] objectsByColor;
    private int row, col;

    // spawning variables
    private Color currentColor;

    public override void Start()
    {
        levelWidth = levelData.width;
        levelHeight = levelData.height;

        row = col = 0;

        Debug.Log("Level width: " + levelWidth);
        Debug.Log("Level height: " + levelHeight);

        x = y = 0;
    }

    public override void Update()
    {
        if (timeToSpawn <= 0)
        {
            SpawnLine();
        }

        timeToSpawn -= Time.deltaTime;
    }

    public void SpawnLine()
    {
        for (int i = 0; i <= levelWidth; ++i)
        {
            currentColor = levelData.GetPixel(i, row);

            if (currentColor != null)
            {

                GameObject g = FindObjectByColor(currentColor);

                if (g != null)
                {
                    Vector3 pos = new Vector3(spawnPointLeft.position.x + i * stepSize, spawnPointLeft.position.y, z);
                    SpawnGameObject(g, pos);
                }
            }

        }
        ++row;
        timeToSpawn = 1.0f;
    }

    public void SpawnGameObject(GameObject g, Vector3 pos)
    {
        Instantiate(g, pos, Quaternion.identity);
    }

    private GameObject FindObjectByColor(Color color)
    {
        foreach (ObjectByColor entry in objectsByColor)
        {
            if (color == entry.c)
            {
                return entry.obj;
            }
        }
        // else
        return null;
    }

    public override void NextWave()
    {

    }
}
