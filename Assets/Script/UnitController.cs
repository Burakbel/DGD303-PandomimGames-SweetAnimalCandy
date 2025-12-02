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
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attackTimer -= Time.deltaTime;
        float moveAmount = 0f;
        Collider2D enemy = Physics2D.OverlapCircle(transform.position + Vector3.right * attackRange, 0.3f, enemyMask);
        if (enemy != null)
        {
            TryAttack(enemy.GetComponent<UnitHealth>());
            SetWalking(false);
            return;
        }


        Collider2D ally = Physics2D.OverlapCircle(transform.position + Vector3.right * followDistance, 0.3f, allyMask);

        if (ally != null)
        {
            moveAmount = moveSpeed * slowDownFactor;
            transform.Translate(Vector3.right * moveAmount * Time.deltaTime);
            Vector3 pushDir = (transform.position - ally.transform.position).normalized;
            transform.position += pushDir * pushBackStrength * Time.deltaTime;
            SetWalking(moveAmount > 0.01f);
            return;
        }


        moveAmount = moveSpeed;
        transform.Translate(Vector3.right * moveAmount * Time.deltaTime);

        SetWalking(moveAmount > 0.01f);
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

    void SetWalking(bool state)
    {
        if (anim != null)
            anim.SetBool("isWalking", state);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * followDistance, 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.right * attackRange, 0.3f);
    }
}
