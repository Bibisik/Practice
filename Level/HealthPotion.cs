using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerAttack;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerAttack = player.GetComponentInChildren<PlayerHealth>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAttack.health.fillAmount += 0.5f;
            Destroy(gameObject);
        }
    }
}
