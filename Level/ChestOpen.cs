using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    [Header("��������� �������� �������")]
    [Tooltip("������ � ������� �")]
    [SerializeField] private GameObject buttonE;
    [Tooltip("���� �� �������")]
    [SerializeField] private new GameObject light;
    [Space]
    [Tooltip("�����")]
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
