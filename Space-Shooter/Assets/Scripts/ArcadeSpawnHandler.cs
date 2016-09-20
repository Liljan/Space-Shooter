using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArcadeSpawnHandler : MonoBehaviour
{
    // references to other memebers
    private LevelHandler levelHandler;

    private float width;
    private float x, y, z;

    float cols = 20f;
    float stepSize, currentCol;

    public Transform spawnPointLeft, spawnPointRight, stopPoint;

    // timers
    public float maxSpawnTime = 3f;
    public float timeToSpawn;

    // spawn
    private int wave = 0;

    public GameObject TieFighter;
    public GameObject TieBomber;
    public GameObject TieInterceptor;

    private int nEnemiesLeft;
    private int nMaxFighters = 0;
    private int nFighters;

    private int nBombers = 0;
    private int nInterceptors = 0;

    // Use this for initialization
    void Start()
    {
        width = spawnPointRight.position.x - spawnPointLeft.position.x;
        y = spawnPointLeft.position.y;
        z = spawnPointLeft.position.z;
        stepSize = width / cols;

        timeToSpawn = Random.Range(0f, maxSpawnTime);
        NextWave();
    }

    Vector3 GetRandomPos()
    {
        x = Mathf.Round(Random.Range(-width / 2, width / 2));
        return new Vector3(x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToSpawn <= 0f)
        {
            SpawnRandom();

            timeToSpawn = Random.Range(0f, maxSpawnTime);
        }

        timeToSpawn -= Time.deltaTime;
    }

    public void SpawnRandom()
    {
        if (nFighters >= 0)
        {
            SpawnGameObject(TieFighter);
        }
    }

    public void SpawnGameObject(GameObject g)
    {
        Instantiate(g, GetRandomPos(), Quaternion.identity);
    }

    public void NextWave()
    {
        //nEnemiesToSpawn += 10;
        nMaxFighters += 10;
        nFighters = nMaxFighters;
    }
}
