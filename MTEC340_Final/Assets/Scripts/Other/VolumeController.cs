using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        
        volumeSlider.value = AudioListener.volume;

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
       
        AudioListener.volume = volume;
    }

    private void OnDestroy()
    {
        
        volumeSlider.onValueChanged.RemoveListener(SetVolume);
    }
}