using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject gate;
    public int totalWaves = 3;        
    public float startDelay = 1.0f;

    private int currentWaveCount = 0;
    private bool roomCleared = false;
    private float timer;
    private bool waveInProgress = false;

    void Start()
    {
        timer = startDelay;
    }

    public void StartNextWave()
    {
        currentWaveCount++;
        waveInProgress = true;
        Debug.Log("Wave " + currentWaveCount + " started!");
    }

    void Update()
    {
        if (roomCleared) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && currentWaveCount >= totalWaves)
        {
            OpenGate();
        }
        else if (enemies.Length == 0 && currentWaveCount < totalWaves)
        {
            waveInProgress = false;
        }
    }

    void OpenGate()
    {
        roomCleared = true;
        Debug.Log("All Waves Cleared! Gate is opening.");

        Animator anim = gate.GetComponent<Animator>();
        if (anim != null)
        {
            anim.SetTrigger("open");
        }

        BoxCollider2D col = gate.GetComponent<BoxCollider2D>();
        if (col != null)
        {
            col.enabled = false;
        }
    }
}