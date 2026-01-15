using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 4f;
    public float fireRate = 1f;
    public int damage = 5;

    public Transform firePoint;
    public GameObject projectilePrefab;
    public LayerMask enemyLayer;

    float fireTimer;

    void Update()
    {
        fireTimer -= Time.deltaTime;

        Collider2D target = FindTarget();

        if (target != null && fireTimer <= 0)
        {
            Shoot(target.transform);
            fireTimer = 1f / fireRate;
        }
    }

    Collider2D FindTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(
            transform.position,
            range,
            enemyLayer
        );

        float closest = Mathf.Infinity;
        Collider2D target = null;

        foreach (var e in enemies)
        {
            float dist = Vector2.Distance(transform.position, e.transform.position);
            if (dist < closest)
            {
                closest = dist;
                target = e;
            }
        }

        return target;
    }

    void Shoot(Transform target)
    {
        GameObject proj = Instantiate(
            projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        proj.GetComponent<Projectile>().Init(target, damage);
    }
}
