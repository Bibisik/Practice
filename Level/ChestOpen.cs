using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [Header("Парамктры открытия сундука")]
    [Tooltip("Канвас с кнопкой Е")]
    [SerializeField] private GameObject buttonE;
    [Tooltip("Свет от сундука")]
    [SerializeField] private new GameObject light;
    [Space]
    [Tooltip("Игрок")]
    [SerializeField] private GameObject player;

    private PlayerAttack playerAttack;
    private bool isTrigger;
    private BoxCollider2D boxCol;
    private Animator anim;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerAttack = player.GetComponent<PlayerAttack>();
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKey(KeyCode.E))
            {
                anim.SetTrigger("isOpen");
                boxCol.enabled = false;
                light.SetActive(false);

                playerAttack.arrowCol += Random.Range(2, 5);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = true;
            buttonE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
        buttonE.SetActive(false);
    }
}
