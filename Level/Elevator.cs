using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("��������� �����")]
    [Tooltip("�����")]
    [SerializeField] private Animator lever;
    [Tooltip("������ E")]
    [SerializeField] private GameObject keyE;
    [Tooltip("����")]
    [SerializeField] private Animator elevator; 


    private bool isTrigger;
    private BoxCollider2D boxCol;
    public static bool start;
    public static bool stopElevator = false;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();

        //��� � �������� ��������� ����� ����� ��� ����� ����� 6
        //� �� ���� ��� �� ���� ������� ��������
        if (stopElevator)
        {
            elevator.SetTrigger("End");
            start = false;
        }
        else
        {
            start = false;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (isTrigger)
            {
                lever.SetTrigger("Down");
                boxCol.enabled = false;
                MainSoundManager.snd.LeverDown();
                start = true;
            }

        }

        if (start)
        {
            elevator.SetTrigger("Start");
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = true;
            keyE.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTrigger = false;
            keyE.SetActive(false);
        }
    }

}
