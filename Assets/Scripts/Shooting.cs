using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shooting;
    public float bulletForce;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()

    {

        GameObject bullet = Instantiate(bulletPrefab, shooting.position, shooting.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(shooting.up * bulletForce, ForceMode2D.Impulse);

    }
}
