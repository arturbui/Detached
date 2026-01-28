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
    public GameObject gateCamera;
    public float cameraWaitTime = 2.0f;

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
                StartCoroutine(ProcessGateOpening());
            }
        }
    }

    IEnumerator SpawnWave()
    {
        spawning = true;
        int enemiesToSpawn = waves[currentWaveIndex];
        List<int> availableIndices = new List<int>();

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (availableIndices.Count == 0)
            {
                for (int j = 0; j < spawnPoints.Length; j++) availableIndices.Add(j);
            }

            int randomIndex = Random.Range(0, availableIndices.Count);
            int spawnPointIndex = availableIndices[randomIndex];
            availableIndices.RemoveAt(randomIndex);

            Transform selectedPoint = spawnPoints[spawnPointIndex];
            Vector3 jitter = new Vector3(Random.Range(-0.7f, 0.7f), Random.Range(-0.7f, 0.7f), 0);
            Instantiate(enemyPrefab, selectedPoint.position + jitter, Quaternion.identity);

            yield return new WaitForSeconds(0.4f);
        }

        currentWaveIndex++;
        spawning = false;
    }

    IEnumerator ProcessGateOpening()
    {
        allWavesCleared = true;

        if (gateCamera != null) gateCamera.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        if (gate != null)
        {
            Animator anim = gate.GetComponent<Animator>();
            if (anim != null) anim.SetTrigger("open");

            BoxCollider2D col = gate.GetComponent<BoxCollider2D>();
            if (col != null) col.enabled = false;
        }

        yield return new WaitForSeconds(cameraWaitTime);

        if (gateCamera != null) gateCamera.SetActive(false);

        this.enabled = false;
    }
}