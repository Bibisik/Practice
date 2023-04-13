using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("��������� ��� �������")]
    [Tooltip("�����")]
    [SerializeField]public Transform player;
    [Tooltip("����� ���������")]
    public int index;
    [Header("���������")]
    [SerializeField] private GameObject fireFlies;
    [Header("����� �� �������� ����� ������")]
    [SerializeField] private GameObject playerSet;

    private int arr;
    private float hp;
    private int expEnemy;

    private void Awake()
    {
        BossElements.elements = 0;
        player = GameObject.Find("Player").transform;
        playerSet = GameObject.Find("Player");

        if(DataContainer.checkPointIndex == index)
        {
            //���������� ������ ���������� � ����������
            player.position = transform.position;
            arr = DataContainer.arrows;                        
            hp = DataContainer.health;
            expEnemy = DataContainer.enemyExp;

            //�������� ������ �� ��� ������
            playerSet.GetComponent<PlayerAttack>().arrowCol = arr;
            playerSet.GetComponentInChildren<PlayerHealth>().health.fillAmount = hp;
            ScoreCounter.enemys = expEnemy;
            BossElements.elements = 0;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            fireFlies.SetActive(false);

            if (index > DataContainer.checkPointIndex)
            {
                //����������� ������ � ���������� �� ���-������
                DataContainer.checkPointIndex = index;
                DataContainer.arrows = playerSet.GetComponent<PlayerAttack>().arrowCol;
                DataContainer.health = playerSet.GetComponentInChildren<PlayerHealth>().health.fillAmount;
                DataContainer.enemyExp = ScoreCounter.enemys;

                //��� ���������� 6�� ��� ������ ����������� ��������� �����
                if(index == 6)
                {
                    Elevator.stopElevator = true;
                }
                
            }
        }
       
    }

}
