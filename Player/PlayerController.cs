using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("��������� ������������ ���������")]
    [Tooltip("�������� �� �������� ������")]
    public bool isMove;

    [Tooltip("�������� ���������")]
    public float speed;
    [Header("��������� ������")]
    [Tooltip("���� ������")]
    [SerializeField] private float jumpForce;
    [Tooltip("�������� �� ����� �� �����")]
    public bool isGround;

    public bool faceRight = true;
    private Rigidbody2D rb;
    private Animator anim;
    private float movement;
    private float rayDist = 0.06f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isMove = true;
    }

    private void Update()
    {
        Movement();
        Jump();
    }
    /// <summary>
    /// ������ �������� ������
    /// </summary>
    void Movement()
    {
        if (isMove)
        {
            movement = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            if (movement > 0 && !faceRight)
                Flip();
            else if (movement < 0 && faceRight)
                Flip();
        }
        anim.SetFloat("Velocity", rb.velocity.magnitude);

    }

    /// <summary>
    /// ������ ������
    /// </summary>
    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, rayDist, LayerMask.GetMask("Ground"));

        if (hit.collider != null)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround && isMove && this.enabled)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        anim.SetBool("onGround", isGround);
    }

    /// <summary>
    /// ������ ��������� ������� ������ ��� ��������
    /// </summary>
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}