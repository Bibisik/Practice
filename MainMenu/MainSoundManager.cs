using UnityEngine;

public class MainSoundManager : MonoBehaviour
{
    public static MainSoundManager snd;
    [SerializeField] private AudioSource audioSrc;
    [Header("Звук наведения на кнопку")]
    [SerializeField] private AudioClip soundMouseEnter;
    [Header("Звук нажатия на кнопку")]
    [SerializeField] private AudioClip soundButtonClick;
    [Header("Звук полёта стрелы")]
    [SerializeField] private AudioClip arrowFly;
    [Header("Звук смерти персонажа")]
    [SerializeField] private AudioClip playerDie;
    [Header("Звук атаки персонажа")]
    [SerializeField] private AudioClip playerAttack;
    [Header("Звук смерти гриба")]
    [SerializeField] private AudioClip mushDie;
    [Header("Звук рычага")]
    [SerializeField] private AudioClip lever;
    [Header("Звук заклинания босса")]
    [SerializeField] private AudioClip bossSpell;
    [Header("Звук смерти босса")]
    [SerializeField] private AudioClip bossDie;


    private void Start()
    {
        snd = this;
    }


    /// <summary>
    /// Метод наведения мышки на кнопки меню
    /// </summary>
    public void PlaySoundMouseEnter()
    {
        audioSrc.PlayOneShot(soundMouseEnter);
    }

    /// <summary>
    /// Метод нажатия по кнопки меню
    /// </summary>
    public void PlaySoundButtonClick()
    {
        audioSrc.PlayOneShot(soundButtonClick);
    }

    /// <summary>
    /// Звук полёта стрелы
    /// </summary>
    public void PlaySoundArrowFly()
    {
        audioSrc.PlayOneShot(arrowFly);
    }

    /// <summary>
    /// Звук смерти персонажа
    /// </summary>
    public void PlayerDie()
    {
        audioSrc.PlayOneShot(playerDie);
    }

    /// <summary>
    /// Звук ближней атаки
    /// </summary>
    public void PlayerAttack()
    {
        audioSrc.PlayOneShot(playerAttack);
    }

    /// <summary>
    /// Звук смерти гриба
    /// </summary>
    public void MushDie()
    {
        audioSrc.PlayOneShot(mushDie);
    }

    /// <summary>
    /// Звук рычага
    /// </summary>
    public void LeverDown()
    {
        audioSrc.PlayOneShot(lever);
    }

    /// <summary>
    /// Звук заклинания
    /// </summary>
    public void BossSpell()
    {
        audioSrc.PlayOneShot(bossSpell);
    }
    /// <summary>
    /// Звук смерти босса
    /// </summary>
    public void BossDie()
    {
        audioSrc.PlayOneShot(bossDie);
    }
}
