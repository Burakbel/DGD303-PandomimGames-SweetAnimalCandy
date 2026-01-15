using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 8f;

    Transform target;
    int damage;

    public void Init(Transform target, int damage)
    {
        this.target = target;
        this.damage = damage;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            Hit();
        }
    }

    void Hit()
    {
        UnitHealth hp = target.GetComponent<UnitHealth>();
        if (hp != null)
            hp.TakeDamage(damage);

        Destroy(gameObject);
    }
}
