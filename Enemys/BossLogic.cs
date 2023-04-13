using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossLogic : MonoBehaviour
{
    [Header("�������� �����")]
    [SerializeField] private Image bossHp;
    [Tooltip("���")]
    [SerializeField] private GameObject shild;
    [Header("����� �����")]
    [Tooltip("����� ��������� ��������")]
    [SerializeField] private Transform[] attackPoints;
    [Tooltip("�������")]
    [SerializeField] private GameObject magicBall;
    [Header("�������� �����")]
    [Tooltip("�������")]
    [SerializeField] private Transform[] points;
    [Tooltip("�������� ������������")]
    private float speed = 10;

    private int currentPoint;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D boxCol;

    private float attackTimer;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    public void Attack()
    {
        for (int i = Random.Range(0, 5); i < attackPoints.Length; i++)
        {
            Instantiate(magicBall, attackPoints[i]);
            MainSoundManager.snd.BossSpell();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            bossHp.fillAmount -= 1f;     //�� ����� �������, �������..))
            MainSoundManager.snd.BossDie();
            ScoreCounter.enemys += 1000;
        }
    }
    private void Die()
    {
        anim.SetTrigger("Die");
        StartCoroutine(bossDie());
    }

    private void Update()
    {
        if (BossTimeline.start)
        {
            shild.SetActive(true);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, points[currentPoint].position, Time.deltaTime * speed);

            if (bossHp.fillAmount < 0.7f)
            {
                if(currentPoint == 0)
                {
                    sr.flipX = false;
                    currentPoint++;
                }
            }
            if(bossHp.fillAmount < 0.4f)
            {
                if (currentPoint == 1)
                {
                    sr.flipX = true;
                    currentPoint++;
                    

                }
            }
            if (bossHp.fillAmount < 0.1f)
            {
                shild.SetActive(false);

                if (currentPoint == 2)
                {
                    currentPoint++;
                }
            }

            if(bossHp.fillAmount <= 0)
            {
                Die();
                boxCol.enabled = false;
            }

            attackTimer += Time.deltaTime;

            if (attackTimer >= 3)
            {
                anim.SetBool("Attack", true);

            }
            if (attackTimer >= 5)
            {
                anim.SetBool("Attack", false);
                attackTimer = 0;
            }

        }

    }
    IEnumerator bossDie()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }
}
