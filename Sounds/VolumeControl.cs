using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [Header("��������� ������������� ���������")]
    [SerializeField] public string volumeParametr = "MasterVolume";
    [SerializeField] public AudioMixer mixer;
    [SerializeField] public Slider slider;

    private float _volumeValue; // ��� ���������� ��������� ���������
    private const float _multiplier = 20f;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float value)
    {
        _volumeValue = Mathf.Log10(value) * _multiplier;
        mixer.SetFloat(volumeParametr, _volumeValue);
    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(slider.value) * _multiplier); //�������� ��� ������ ��������� ����������� ���������
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
    }


}
