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

    private float nextFireTime;
    private Animator anim;
    private Vector3 lastPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
        lastPos = transform.position;
    }

    void Update()
    {
        if (player == null) return;

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
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }
}