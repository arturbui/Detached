using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip playerBullet;
    public AudioClip enemyBullet;
    public AudioClip playerHit;
    public AudioClip footsteps;
    public AudioClip gateOpen;
    public AudioClip bossLazer;
    public AudioClip enemyHit;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("AudioManager: You are trying to play a NULL clip!");
            return;
        }
        Debug.Log("AudioManager is playing: " + clip.name);
        sfxSource.PlayOneShot(clip);
    }
}