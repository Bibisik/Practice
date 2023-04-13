using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("Настройки камеры")]
    [Tooltip("Активная камера камера")]
    [SerializeField] private GameObject activeCam;
    [Tooltip("Вторая камера")]
    [SerializeField] private GameObject secondCam;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activeCam.SetActive(true);
            secondCam.SetActive(false);
        }
    }
}
