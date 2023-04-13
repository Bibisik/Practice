using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Клон стрелы")]
    [SerializeField] private GameObject arrow;
    [Header("Взрыв стрелы")]
    [SerializeField] private GameObject explosion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Element")
        {
            Destroy(arrow);
            explosion.SetActive(true);
            Destroy(gameObject, 0.5f);

        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("CamCollider"))
        {
            Destroy(gameObject);
        }
    }

}
