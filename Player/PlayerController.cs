using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Параметры передвижения персонажа")]
    [Tooltip("Проверка на движение игрока")]
    public bool isMove;

    [Tooltip("Скорость персонажа")]
    public float speed;
    [Header("Параметры прыжка")]
    [Tooltip("Сила прыжка")]
    [SerializeField] private float jumpForce;
    [Tooltip("Проверка на земле ли игрок")]
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
    /// Логика движения игрока
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
    /// Логика прыжка
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
    /// Логика разворота спрайта игрока при движении
    /// </summary>
    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}