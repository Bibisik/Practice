using UnityEngine;
using UnityEngine.UI;


public class BossElements : MonoBehaviour
{
    [Tooltip("����������� ������")]
    public int health;
    [Tooltip("������� ������")]
    [SerializeField]private GameObject ps;
    [Tooltip("����� ��������")]
    [SerializeField]private GameObject explosion;
    [Tooltip("������� �� �����")]
    [SerializeField]private Image bossHealth;
    [Tooltip("������ ���������")]
    [SerializeField]private GameObject[] bossElements;

    private SpriteRenderer sr;
    private BoxCollider2D bc;

    public static int elements;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        bossElements[elements].SetActive(true);
         
        if(elements == 2)
        {
            this.enabled = false;   
        }
    }

    public void DestroyElement()
    {
        sr.enabled = false;
        ps.SetActive(false);
        explosion.SetActive(true);
        Destroy(gameObject, 1.5f);
        bossHealth.fillAmount -= 0.33f;
        bc.enabled = false;
        elements++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            health -= 20;
            if(health <= 0)
            {
                DestroyElement();
            }
        }
    }
}
