using UnityEngine;
public class EnemyMeele : MonoBehaviour
{
    [Header("��������� �����")]
    [Tooltip("����������� �����")]
    [SerializeField] private float attackCooldown;
    [Tooltip("�������� �����")]
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [Tooltip("���� �� �����")]
    [SerializeField] private float damage;
    [Tooltip("��������� �����")]
    [SerializeField] private BoxCollider2D boxCollider;
    [Tooltip("����� ������")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private PlayerHealth ph;
    private PlayerAttack pa;
    private Animator anim;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("isAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();

    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            ph = hit.transform.GetComponentInChildren<PlayerHealth>();
            pa = hit.transform.GetComponent<PlayerAttack>();
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
           new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    public void Damage()
    {
        if (PlayerInSight())
        {
            if (pa.isShild)
            {
                ph.TakeDamage(0f);
            }
            else if(ph.isAlive)
            {
                ph.TakeDamage(damage);
            }

            
        }
    }
}
