using UnityEngine;

public class Elevator : MonoBehaviour
{
    [Header("Настройки лифта")]
    [Tooltip("Рычаг")]
    [SerializeField] private Animator lever;
    [Tooltip("Кнопка E")]
    [SerializeField] private GameObject keyE;
    [Tooltip("Лифт")]
    [SerializeField] private Animator elevator; 


    private bool isTrigger;
    private BoxCollider2D boxCol;
    public static bool start;
    public static bool stopElevator = false;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();

        //Тут я описываю состояние лифта после чек поита номер 6
        //и до того как до него доходит персонаж
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
