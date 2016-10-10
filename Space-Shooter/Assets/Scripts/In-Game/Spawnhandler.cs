using UnityEngine;
using System.Collections;

public abstract class Spawnhandler : MonoBehaviour
{
    // reference to level handler and sound handler.
    protected LevelHandler levelHandler;

    // spawn placement variables
    protected float width;
    protected float x, y, z;

    protected float cols = 20f;
    protected float stepSize;

    public Transform spawnPointLeft, spawnPointRight, stopPoint;

    // spawn variables
    protected int currentWave = 0;
    protected int enemiesLeft;

    // spawn timers
    public const float MAX_SPAWN_TIME = 3f;
    protected float timeToSpawn;

    public void Awake()
    {
        InitSpawnPoints();
    }

    public abstract void Start();

    protected void InitSpawnPoints()
    {
        width = spawnPointRight.position.x - spawnPointLeft.position.x;
        y = spawnPointLeft.position.y;
        z = spawnPointLeft.position.z;
        stepSize = width / cols;
    }

    public abstract void Update();

   // public abstract void SpawnGameObject(GameObject g, Vector2 pos);

    protected void SetRemainingEnemies()
    {
        levelHandler.SetRemainingEnemies(enemiesLeft);
    }

    protected void DisplayWaveText()
    {
        levelHandler.DisplayWaveText(currentWave);
    }

    public abstract void NextWave();

}
