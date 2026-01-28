using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [Header("Wave Settings")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public List<int> waves = new List<int> { 3, 5, 8 };

    [Header("Gate Settings")]
    public GameObject gate; 

    private int currentWaveIndex = 0;
    private bool spawning = false;
    private bool allWavesCleared = false;

    void Update()
    {
        
        if (allWavesCleared) return;
        if (!spawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (currentWaveIndex < waves.Count)
            {
                StartCoroutine(SpawnWave());
            }
            else
            {
                OpenGate();
            }
        }
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        Debug.Log("Starting Wave " + (currentWaveIndex + 1));

        for (int i = 0; i < waves[currentWaveIndex]; i++)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        currentWaveIndex++;
        spawning = false;
    }

    void OpenGate()
    {
        allWavesCleared = true;
        Debug.Log("All waves complete! Opening gate.");

        if (gate != null)
        {
            Animator anim = gate.GetComponent<Animator>();
            if (anim != null) anim.SetTrigger("open");
            BoxCollider2D col = gate.GetComponent<BoxCollider2D>();
            if (col != null) col.enabled = false;
        }

        this.enabled = false; 
    }
}