using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Начисление очков за смерть")]
    [Tooltip("Очки за смерть")]
    private int scoreEnemy;
    [Tooltip("Очки от:")]
    [SerializeField] private int firstScore;
    [Tooltip("Очки до:")]
    [SerializeField] private int secondScore;

    [Header("Параметры жизни врага")]
    [Tooltip("Колличество жизней")]
    public int health;
    [Tooltip("Родительский объект врага")]
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
    /// Метод смерти врага
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
