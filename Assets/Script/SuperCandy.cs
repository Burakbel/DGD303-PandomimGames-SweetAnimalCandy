using UnityEngine;

public class SuperCandy : MonoBehaviour
{
    public float speed = 15f;
    public int damage = 20;

    [Header("Rotation")]
    public float rollTorque = -300f; 

    [Header("Hit Settings")]
    public LayerMask enemyLayer;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);


        rb.AddTorque(rollTorque);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((enemyLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            UnitHealth health = other.GetComponent<UnitHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    void Update()
    {
        
        if (transform.position.x > 60f)
        {
            Destroy(gameObject);
        }
    }
}
