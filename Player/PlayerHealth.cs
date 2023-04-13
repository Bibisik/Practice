using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Проверка жив ли персонаж")]
    public bool isAlive;
    [Header("Настройки урона по игроку")]
    [Tooltip("Полоска хп")]
    [SerializeField] public Image health;
    [Tooltip("Урон от дальних атак")]
    [SerializeField] private float damageDist;

    private PlayerAttack playerAttack;
    private PlayerController playerController;
    private Animator anim;
    private BoxCollider2D boxCol;

    private void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
        playerController = GetComponentInParent<PlayerController>();
        anim = GetComponentInParent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        isAlive = true;
    }

    /// <summary>
    /// Логика получения урона
    /// </summary>
    public void TakeDamage(float damage)
    {
        if (!playerAttack.isShild)
        {
            anim.SetTrigger("isDamage");
            health.fillAmount -= damage;
        }

        if (health.fillAmount == 0)
        {
            Die();
            StartCoroutine(die());
        }
    }

    /// <summary>
    /// Логика смерти
    /// </summary>
    public void Die()
    {
        MainSoundManager.snd.PlayerDie();
        playerController.enabled = false;
        playerAttack.enabled = false;
        boxCol.enabled = false;
        anim.SetTrigger("isDie");

        isAlive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Bullet"))
        {
            TakeDamage(damageDist);
            anim.SetTrigger("isDamage");
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
