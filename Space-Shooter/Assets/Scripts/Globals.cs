using UnityEngine;
using System.Collections;

public class Globals : Singleton<Globals>
{
    protected Globals() { } // Protect the constructor!

    private bool paused = false;
    private int score = 0;

    void Awake()
    {
        Debug.Log("Awoke Singleton Instance: " + gameObject.GetInstanceID());
    }

    public bool IsPaused() { return paused; }
    public void SetPaused(bool b)
    {
        paused = b;

        if (paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
