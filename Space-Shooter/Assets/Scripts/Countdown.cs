﻿using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public float timer = 0.5f;
    public GameObject waveMessage;
    public GameObject waveNumberText;

   // public SpawnHandler spawnHandler;

    // Use this for initialization
    void Start()
    {
       // ShowMessages();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowWaveNumber(int nWaves)
    {
       // waveNumberText.text = "Wave " + nWaves;
        StartCoroutine(FinalCountdown(timer,nWaves));
    }

    IEnumerator FinalCountdown(float t, int nWaves)
    {
        yield return new WaitForSeconds(t);
        GameObject g1 = Instantiate(waveMessage, transform.position, Quaternion.identity) as GameObject;
        g1.transform.SetParent(this.transform);
        yield return new WaitForSeconds(t);
        Destroy(g1);

        GameObject g2 = Instantiate(waveNumberText, transform.position, Quaternion.identity) as GameObject;
        g2.transform.SetParent(this.transform);
        g2.GetComponent<Text>().text = "Wave " + nWaves;
        yield return new WaitForSeconds(t);
        Destroy(g2);

    }
}
