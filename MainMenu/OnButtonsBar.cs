using UnityEngine;

public class OnButtonsBar : MonoBehaviour
{
    [Header("Рамка кнопки")]
    [SerializeField] private GameObject bar;

    private void OnMouseEnter()
    {
        MainSoundManager.snd.PlaySoundMouseEnter();
        bar.SetActive(true);
    }

    private void OnMouseExit()
    {
        bar.SetActive(false);
    }
    private void OnMouseDown()
    {
        bar.SetActive(false);
    }
}
