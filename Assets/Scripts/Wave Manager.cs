using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public List<int> waves = new List<int> { 3, 5, 8 };

    private int currentWaveIndex = 0;
    private bool spawning = false;

    void Update()
    {
        if (!spawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            if (currentWaveIndex < waves.Count)
            {
                StartCoroutine(SpawnWave());
            }
            else
            {
                Debug.Log("All waves complete! Door to Boss opened.");
                this.enabled = false;
            }
        }
    }

    IEnumerator SpawnWave()
    {
        spawning = true;

        for (int i = 0; i < waves[currentWaveIndex]; i++)
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        currentWaveIndex++;
        spawning = false;
    }
}
