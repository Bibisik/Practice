using UnityEngine;

public class MainSoundManager : MonoBehaviour
{
    public static MainSoundManager snd;
    [SerializeField] private AudioSource audioSrc;
    [Header("���� ��������� �� ������")]
    [SerializeField] private AudioClip soundMouseEnter;
    [Header("���� ������� �� ������")]
    [SerializeField] private AudioClip soundButtonClick;
    [Header("���� ����� ������")]
    [SerializeField] private AudioClip arrowFly;
    [Header("���� ������ ���������")]
    [SerializeField] private AudioClip playerDie;
    [Header("���� ����� ���������")]
    [SerializeField] private AudioClip playerAttack;
    [Header("���� ������ �����")]
    [SerializeField] private AudioClip mushDie;
    [Header("���� ������")]
    [SerializeField] private AudioClip lever;
    [Header("���� ���������� �����")]
    [SerializeField] private AudioClip bossSpell;
    [Header("���� ������ �����")]
    [SerializeField] private AudioClip bossDie;


    private void Start()
    {
        snd = this;
    }


    /// <summary>
    /// ����� ��������� ����� �� ������ ����
    /// </summary>
    public void PlaySoundMouseEnter()
    {
        audioSrc.PlayOneShot(soundMouseEnter);
    }

    /// <summary>
    /// ����� ������� �� ������ ����
    /// </summary>
    public void PlaySoundButtonClick()
    {
        audioSrc.PlayOneShot(soundButtonClick);
    }

    /// <summary>
    /// ���� ����� ������
    /// </summary>
    public void PlaySoundArrowFly()
    {
        audioSrc.PlayOneShot(arrowFly);
    }

    /// <summary>
    /// ���� ������ ���������
    /// </summary>
    public void PlayerDie()
    {
        audioSrc.PlayOneShot(playerDie);
    }

    /// <summary>
    /// ���� ������� �����
    /// </summary>
    public void PlayerAttack()
    {
        audioSrc.PlayOneShot(playerAttack);
    }

    /// <summary>
    /// ���� ������ �����
    /// </summary>
    public void MushDie()
    {
        audioSrc.PlayOneShot(mushDie);
    }

    /// <summary>
    /// ���� ������
    /// </summary>
    public void LeverDown()
    {
        audioSrc.PlayOneShot(lever);
    }

    /// <summary>
    /// ���� ����������
    /// </summary>
    public void BossSpell()
    {
        audioSrc.PlayOneShot(bossSpell);
    }
    /// <summary>
    /// ���� ������ �����
    /// </summary>
    public void BossDie()
    {
        audioSrc.PlayOneShot(bossDie);
    }
}
