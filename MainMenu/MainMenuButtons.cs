using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip audioClip;

    //Логика нажатия кнопок меню
    public void StartGameButton()
    {
        MainSoundManager.snd.PlaySoundButtonClick();
        SceneManager.LoadScene(1);
        audioSrc.clip = audioClip;
        audioSrc.Play();
    }

    public void SettingsButton()
    {
        MainSoundManager.snd.PlaySoundButtonClick();
    }

    public void QuitButton()
    {
        MainSoundManager.snd.PlaySoundButtonClick();
        Application.Quit();
    }


}
