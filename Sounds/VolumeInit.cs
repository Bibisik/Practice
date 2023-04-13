using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    [Header("Имя параметра микшера")]
    [SerializeField] private string volumeParameter = "MasterVolume";
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParameter, 0f);
        mixer.SetFloat(volumeParameter, volumeValue);
    }

   
}
