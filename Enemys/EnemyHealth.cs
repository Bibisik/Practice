using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("���������� ����� �� ������")]
    [Tooltip("���� �� ������")]
    private int scoreEnemy;
    [Tooltip("���� ��:")]
    [SerializeField] private int firstScore;
    [Tooltip("���� ��:")]
    [SerializeField] private int secondScore;

    [Header("��������� ����� �����")]
    [Tooltip("����������� ������")]
    public int health;
    [Tooltip("������������ ������ �����")]
    [SerializeField] private GameObject enemy;

    private Animator anim;
    private BoxCollider2D boxCol;
    private EnemyPatrol enemyPatrol;
    private EnemyMeele enemyMeele;

    private void Start()
    {
        anim = GetComponent<Animator>();
        scoreEnemy = Random.Range(firstScore,secondScore);
        boxCol = GetComponent <BoxCollider2D>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
        enemyMeele = GetComponentInParent<EnemyMeele>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Arrow")
        {
            health -= Random.Range(5,8);
            anim.SetTrigger("isDamage");
            if(health <= 0)
            {
                Die();
            }
        }
    }

    /// <summary>
    /// ����� ������ �����
    /// </summary>
    public void Die() 
    {
        anim.SetTrigger("isDie");
        MainSoundManager.snd.MushDie();

        ScoreCounter.enemys += scoreEnemy;
        boxCol.enabled = false;

        if(enemyPatrol != null)
            enemyPatrol.enabled = false;

        if(enemyMeele != null)
            enemyMeele.enabled = false;

        Destroy(enemy, 2f);
    }
}
