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
        // test
        if (row == 0) {
            SpawnLine();
        }
    }

    public void SpawnLine()
    {
        for (int i = 0; i <= levelWidth; ++i)
        {
            currentColor = levelData.GetPixel(i, row);
            
            if (currentColor != null)
            {

                GameObject g = FindObjectByColor(currentColor);
                Debug.Log("Current color: " + g);
                if (g != null)
                {
                    Vector2 pos = new Vector2(spawnPointLeft.position.x + i * stepSize, spawnPointLeft.position.y);
                    SpawnGameObject(g,pos);
                }
            }

        }
        ++row;
    }

    public override void SpawnGameObject(GameObject g, Vector2 pos)
    {
        throw new NotImplementedException();
    }

    private GameObject FindObjectByColor(Color color)
    {
        foreach (ObjectByColor entry in objectsByColor)
            if (color == entry.c)
                return entry.obj;
        // else
        return null;
    }




}
