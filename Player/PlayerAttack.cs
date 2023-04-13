using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    [Tooltip("�������� �����")]
    public bool isAttack;

    [Header("��������� ��������")]
    [Tooltip("������� ������ ������")]
    [SerializeField] private Transform firePoint;
    [Tooltip("������ ������")]
    [SerializeField] private GameObject arrow;
    [Tooltip("�������� ����� ������")]
    [SerializeField] private float arrowSpeed;
    [Tooltip("����� ����������� ��������")]
    [SerializeField] private float attackRate = 2f;
    [Tooltip("����������� ����� ���:")]
    public int arrowCol;

    [Tooltip("������� �����")]
    [SerializeField] private Text arrowCounter;
    [Header("��������� ������� �����")]
    [Tooltip("������� �����")]
    [SerializeField] private Transform attackPos;
    [Tooltip("������ �����")]
    [SerializeField] private float attackRange;
    [Tooltip("��������� ����")]
    [SerializeField] private int damage;

    [Space]
    [Header("��������� ����")]
    [Tooltip("��������� ����")]
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
    /// ������ ����
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
    /// ������ ��������
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
    /// ������ ������� �����
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
    /// ������ �������� ������ � �������� �� ����
    /// ���� ����� ���������, ��� ��� �� ������� � �������� � �������� ��������
    /// </summary>
    public void ArrowFly()
    {
        var arr =  Instantiate(arrow, firePoint);
        var arrFly = arr.GetComponent<Rigidbody2D>();

        //���������� ����� ������
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
