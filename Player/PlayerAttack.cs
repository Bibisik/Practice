using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("Проверка атаки")]
    public bool isAttack;

    [Header("Настройки стрельбы")]
    [Tooltip("Позиция спавна стрелы")]
    [SerializeField] private Transform firePoint;
    [Tooltip("Префаб стрелы")]
    [SerializeField] private GameObject arrow;
    [Tooltip("Скорость полёта стрелы")]
    [SerializeField] private float arrowSpeed;
    [Tooltip("Время перезарядки выстрела")]
    [SerializeField] private float attackRate = 2f;
    [Tooltip("Колличество стрел мин:")]
    public int arrowCol;

    [Tooltip("Счётчик стрел")]
    [SerializeField] private Text arrowCounter;
    [Header("Настройка ближней атаки")]
    [Tooltip("Позиция атаки")]
    [SerializeField] private Transform attackPos;
    [Tooltip("Радиус атаки")]
    [SerializeField] private float attackRange;
    [Tooltip("Наносимый урон")]
    [SerializeField] private int damage;

    [Space]
    [Header("Настройки щита")]
    [Tooltip("Коллайдер щита")]
    [SerializeField] private GameObject shildCollider;

    private Animator anim;
    private PlayerController pc;
    private int arrowMax = 15;
    private Rigidbody2D rb;
    private float nextAttack = 0f;
    public bool isShild;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pc = GetComponent<PlayerController>();
        isAttack = true;
        isShild = false;
    }

    void Update()
    {
        DistanceAttack();
        MeeleAttack();
        Shild();
        arrowCounter.text = $"{arrowCol}/{arrowMax}";

        if(arrowCol > arrowMax)
        {
            arrowCol = arrowMax;
        }
    }


    /// <summary>
    /// Логика щита
    /// </summary>
    private void Shild()
    {
        if(pc.isGround)
        {
            if (Input.GetKeyDown(KeyCode.Q) && rb.velocity.magnitude == 0)
            {
                isShild = true;
                pc.isMove = false;
                isAttack = false;
                anim.SetBool("Shild",true);
                shildCollider.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                isShild = false;
                pc.isMove = true;
                isAttack = true;
                anim.SetBool("Shild", false);
                shildCollider.SetActive(false);

            }
        }
    }

    /// <summary>
    /// Логика стрельбы
    /// </summary>
    private void DistanceAttack()
    {
        if(Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && pc.isGround == true && isAttack == true && arrowCol > 0)
            {
                pc.speed = 0f;
                arrowCol -= 1;
                anim.SetTrigger("Fire");
                nextAttack = Time.time + 1f / attackRate;
            }
            else
            {
                pc.speed = 4f;
            }
        }
    }

   
    /// <summary>
    /// Логика ближней атаки
    /// </summary>
    private void MeeleAttack()
    {
        if(Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && pc.isGround == true && isAttack == true)
            {
                MainSoundManager.snd.PlayerAttack();

                anim.SetTrigger("Attack");

                Collider2D[] enemys = Physics2D.OverlapCircleAll(attackPos.position,attackRange,LayerMask.GetMask("Enemy"));
                for(int i = 0; i< enemys.Length; i++)
                {
                    enemys[i].GetComponent<EnemyHealth>().health -= damage;
                    enemys[i].GetComponent<Animator>().SetTrigger("isDamage");
                    if (enemys[i].GetComponent<EnemyHealth>().health <= 0)
                    {
                        enemys[i].GetComponent<EnemyHealth>().Die();
                    }
                }

                Collider2D[] elements = Physics2D.OverlapCircleAll(attackPos.position, attackRange, LayerMask.GetMask("Element"));
                for (int i = 0; i < elements.Length; i++)
                {
                    elements[i].GetComponent<BossElements>().health -= (damage * 5);
                    if (elements[i].GetComponent<BossElements>().health <= 0)
                    {
                        elements[i].GetComponent<BossElements>().DestroyElement();
                    }
                }
                nextAttack = Time.time + 0.5f / attackRate;
            }
        }
    }

    /// <summary>
    /// Логика создания стрелы и придание ей силы
    /// Этот метод публичный, так как он завязан с событием в анимацмм стрельбы
    /// </summary>
    public void ArrowFly()
    {
        var arr =  Instantiate(arrow, firePoint);
        var arrFly = arr.GetComponent<Rigidbody2D>();

        //Напрвление полёта стрелы
        if (pc.faceRight)
        {
            arrFly.AddForce(new Vector2(1, 0) * arrowSpeed);
        }
        else if(!pc.faceRight)
        {
            arrFly.AddForce(new Vector2(-1, 0) * arrowSpeed);
        }
        MainSoundManager.snd.PlaySoundArrowFly();

        arrFly.transform.parent = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
