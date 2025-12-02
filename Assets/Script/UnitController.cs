using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float followDistance = 1.5f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public int damage = 5;

    public float slowDownFactor = 0.4f;
    public float pushBackStrength = 0.5f;

    public LayerMask allyMask;
    public LayerMask enemyMask;

    private float attackTimer;

    void Update()
    {
        attackTimer -= Time.deltaTime;

        Collider2D enemy = Physics2D.OverlapCircle(transform.position + Vector3.right * attackRange, 0.3f, enemyMask);

        if (enemy != null)
        {
            TryAttack(enemy.GetComponent<UnitHealth>());
            return;
        }

        Collider2D ally = Physics2D.OverlapCircle(transform.position + Vector3.right * followDistance, 0.3f, allyMask);

        if (ally != null)
        {

            transform.Translate(Vector3.right * (moveSpeed * slowDownFactor) * Time.deltaTime);

            Vector3 pushDir = (transform.position - ally.transform.position).normalized;
            transform.position += pushDir * pushBackStrength * Time.deltaTime;

            return;
        }


        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    void TryAttack(UnitHealth target)
    {
        if (target == null) return;

        if (attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            target.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * followDistance, 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * attackRange, 0.3f);
    }
}
