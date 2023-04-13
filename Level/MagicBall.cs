using UnityEngine;

public class MagicBall : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CircleCollider2D cc;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cc = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            rb.simulated = false;
            sr.enabled = false;
            cc.enabled = false;
            explosion.SetActive(true);
            Destroy(explosion, 0.5f);
            Destroy(transform.parent.gameObject,0.5f);
        }
    }

   
}
