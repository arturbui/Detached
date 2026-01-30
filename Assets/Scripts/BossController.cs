using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public GameObject laserPrefab;
    public Transform firePoint;

    [Header("Movement")]
    public float speed = 2f;
    public float stoppingDistance = 3f;

    [Header("Combat")]
    public float fireRate = 1.2f;
    public float phase2FireRate = 0.8f; 

    private float nextFireTime;
    private Animator anim;
    private Vector3 lastPos;
    private BossHealth healthScript; 
    private bool isPhase2 = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        healthScript = GetComponent<BossHealth>(); 

        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPos = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        if (!isPhase2 && healthScript != null)
        {
            if (healthScript.health <= (healthScript.maxHealth / 2))
            {
                isPhase2 = true;
                fireRate = phase2FireRate;
                Debug.Log("Boss Phase 2 Started!");
            }
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        UpdateAnimation();
        lastPos = transform.position;

        Vector3 dir = player.position - firePoint.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);

        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void UpdateAnimation()
    {
        if (anim == null) return;

        Vector3 moveDir = transform.position - lastPos;

        if (moveDir.magnitude > 0.001f)
        {
            if (Mathf.Abs(moveDir.x) > Mathf.Abs(moveDir.y))
            {
                anim.SetFloat("VelX", Mathf.Sign(moveDir.x));
                anim.SetFloat("VelY", 0);
            }
            else
            {
                anim.SetFloat("VelX", 0);
                anim.SetFloat("VelY", Mathf.Sign(moveDir.y));
            }
        }
    }

    void Shoot()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.bossLazer);
        }

        if (isPhase2)
        {
            for (int i = -1; i <= 1; i++)
            {
                float spreadAngle = i * 15f; 
                Quaternion spreadRotation = firePoint.rotation * Quaternion.Euler(0, 0, spreadAngle);
                Instantiate(laserPrefab, firePoint.position, spreadRotation);
            }
        }
        else
        {
            Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        }
    }
}