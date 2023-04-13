using UnityEngine;

public class EnemyDistanceAttack : MonoBehaviour
{
    [Header("��������� ������� �����")]
    [Tooltip("����� ������ �������")]
    [SerializeField] private Transform spawnPoint;
    [Tooltip("������ �������")]
    [SerializeField] private GameObject bullet;
    [Tooltip("�������� ����� �������")]
    [SerializeField] private float bulletSpeed;
    [Space]
    [Header("������� �����")]
    [Tooltip("�� ����� �����")]
    [SerializeField] private float attackTime;
    [Tooltip("������ ����� ����� :")]
    [SerializeField] private float attackStart;
    [Tooltip("����������������� �����")]
    [SerializeField] private float attackDuration;
    [Tooltip("��������� �����")]
    [SerializeField] private float attackDistance;
    [Tooltip("����������� �����")]
    [SerializeField] private float attackVector;



    private Animator anim;
    private float attackTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AttackTimer();
    }

    /// <summary>
    /// ������ ������� ��������
    /// </summary>
    private void AttackTimer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, attackDistance, LayerMask.GetMask("Player"));

        if (hit.collider)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackStart)
            {
                anim.SetBool("isAttack", true);
            }
            if (attackTimer >= attackDuration)
            {
                anim.SetBool("isAttack", false);
            }
            if (attackTimer >= attackTime)
            {
                attackTimer = 0;
            }
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    /// <summary>
    /// ������ ������� �����
    /// </summary>
    public void Attack()
    {
        var bullets = Instantiate(bullet, spawnPoint);
        bullets.transform.parent = null;
        var bulletFly = bullets.GetComponent<Rigidbody2D>();
        bulletFly.AddForce(new Vector2(attackVector,0) * bulletSpeed);
       

    }

   
}
