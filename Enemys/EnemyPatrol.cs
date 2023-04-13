using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Пункты патруля")]
    [Tooltip("Левый край патруля")]
    [SerializeField] private Transform leftEdge;
    [Tooltip("Правый край патруля")]
    [SerializeField] private Transform rightEdge;

    [Header("Враг")]
    [Tooltip("Позиция игрока")]
    [SerializeField] private Transform enemy;

    [Header("Параметры движения врага")]
    [Tooltip("Скорость врага")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [Tooltip("Время остановки")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Аниматор врага")]
    [SerializeField]private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Walk", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirecionChange();
            }

        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);

            else
            {
                DirecionChange();
            }

        }
    }

    /// <summary>
    /// Поворот врага 
    /// </summary>
    private void DirecionChange()
    {
        anim.SetBool("Walk", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;

    }

    /// <summary>
    /// Движение врага
    /// </summary>
    /// <param name="_direction"></param>
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        anim.SetBool("Walk", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }
}
