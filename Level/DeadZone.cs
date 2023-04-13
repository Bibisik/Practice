using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]private PlayerHealth ph;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ph.TakeDamage(1f);
        }
    }
}
