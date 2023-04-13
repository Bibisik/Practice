using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [Header("��������� ������")]
    [Tooltip("�������� ������ ������")]
    [SerializeField] private GameObject activeCam;
    [Tooltip("������ ������")]
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
