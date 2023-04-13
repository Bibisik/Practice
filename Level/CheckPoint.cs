using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("Настройки чек поинтов")]
    [Tooltip("Игрок")]
    [SerializeField]public Transform player;
    [Tooltip("Номер чекпоинта")]
    public int index;
    [Header("Светлячки")]
    [SerializeField] private GameObject fireFlies;
    [Header("Обьек со скриптом атаки игрока")]
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
            //Сохранение данных контейнера в переменных
            player.position = transform.position;
            arr = DataContainer.arrows;                        
            hp = DataContainer.health;
            expEnemy = DataContainer.enemyExp;

            //Выгрузка данных на чек поинте
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
                //Запоминание данных в контейнере на чек-поинте
                DataContainer.checkPointIndex = index;
                DataContainer.arrows = playerSet.GetComponent<PlayerAttack>().arrowCol;
                DataContainer.health = playerSet.GetComponentInChildren<PlayerHealth>().health.fillAmount;
                DataContainer.enemyExp = ScoreCounter.enemys;

                //При достижении 6го чек поинта сохроняется состояние лифта
                if(index == 6)
                {
                    Elevator.stopElevator = true;
                }
                
            }
        }
       
    }

}
