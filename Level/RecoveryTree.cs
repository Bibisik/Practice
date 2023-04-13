using UnityEngine;

public class RecoveryTree : MonoBehaviour
{
    [Header("Настройки меню выбора")]
    [Tooltip("Панель выбора опции дерева")]
    [SerializeField] private GameObject choisePanel;
    [Tooltip("Скрипт атаки игрока")]
    [SerializeField] private PlayerAttack playerAttack;
    [Tooltip("Скрипт жизни игрока")]
    [SerializeField] private PlayerHealth playerHealth;
    [Space]
    [Header("Настройки эффектов")]
    [Tooltip("Свечение дерева")]
    [SerializeField] private GameObject treeLight;
    [Tooltip("Система частиц дерева")]
    [SerializeField] private GameObject treePartical;

    private bool isTigger;
    private BoxCollider2D boxCol;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        ChoiseMenu();
    }

    private void ChoiseMenu()
    {
        if (isTigger)
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                treeLight.SetActive(false);
                treePartical.SetActive(false);
                playerAttack.arrowCol = 15;
                boxCol.enabled = false;
                choisePanel.SetActive(false);
            }

            if (Input.GetKey(KeyCode.Alpha2))
            {
                treeLight.SetActive(false);
                treePartical.SetActive(false);
                playerHealth.health.fillAmount = 1f;
                boxCol.enabled = false;
                choisePanel.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTigger = true;
            choisePanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTigger = false;
            choisePanel.SetActive(false);
        }
    }
}
