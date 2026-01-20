using UnityEngine;

public class PointerRotation : MonoBehaviour
{
    [SerializeField] private float orbitDistance = 1.0f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPos = transform.parent.position;

        Vector2 direction = (mousePos - playerPos).normalized;

        transform.position = playerPos + (Vector3)(direction * orbitDistance);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}