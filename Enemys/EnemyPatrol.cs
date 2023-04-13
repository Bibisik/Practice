using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("������ �������")]
    [Tooltip("����� ���� �������")]
    [SerializeField] private Transform leftEdge;
    [Tooltip("������ ���� �������")]
    [SerializeField] private Transform rightEdge;

    [Header("����")]
    [Tooltip("������� ������")]
    [SerializeField] private Transform enemy;

    [Header("��������� �������� �����")]
    [Tooltip("�������� �����")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    [Tooltip("����� ���������")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("�������� �����")]
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
    /// ������� ����� 
    /// </summary>
    private void DirecionChange()
    {
        anim.SetBool("Walk", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;

    }

    /// <summary>
    /// �������� �����
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
