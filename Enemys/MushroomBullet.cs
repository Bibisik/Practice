using UnityEngine;

public class MushroomBullet : MonoBehaviour
{
    [Header("Взрыв снаряда")]
    [SerializeField] private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Shild") || collision.CompareTag("Player"))
        {
            explosion.SetActive(true);
            Destroy(gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
