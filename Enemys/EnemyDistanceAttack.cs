using UnityEngine;

public class EnemyDistanceAttack : MonoBehaviour
{
    [Header("Настройки дальней атаки")]
    [Tooltip("Точка спавна снаряда")]
    [SerializeField] private Transform spawnPoint;
    [Tooltip("Префаб снаряда")]
    [SerializeField] private GameObject bullet;
    [Tooltip("Скорость полёта снаряда")]
    [SerializeField] private float bulletSpeed;
    [Space]
    [Header("Тайминг атаки")]
    [Tooltip("Всё время атаки")]
    [SerializeField] private float attackTime;
    [Tooltip("Начало атаки через :")]
    [SerializeField] private float attackStart;
    [Tooltip("Продолжительность атаки")]
    [SerializeField] private float attackDuration;
    [Tooltip("Дистанция атаки")]
    [SerializeField] private float attackDistance;
    [Tooltip("Направление атаки")]
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
    /// Логика таймера стрельбы
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
    /// Логика дальней атаки
    /// </summary>
    public void Attack()
    {
        var bullets = Instantiate(bullet, spawnPoint);
        bullets.transform.parent = null;
        var bulletFly = bullets.GetComponent<Rigidbody2D>();
        bulletFly.AddForce(new Vector2(attackVector,0) * bulletSpeed);
       

    }

   
}
