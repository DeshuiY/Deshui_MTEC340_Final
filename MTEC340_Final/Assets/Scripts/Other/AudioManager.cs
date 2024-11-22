using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider; // 连接滑块组件
    [SerializeField] private AudioSource audioSource; // 连接音频源（主背景音乐或全局音频管理器）

    private void Start()
    {
        // 初始化滑块值为当前音量
        volumeSlider.value = AudioListener.volume;

        // 监听滑块值变化
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        // 设置全局音量
        AudioListener.volume = value;

        // 如果需要单独控制某个 AudioSource 的音量
        if (audioSource != null)
        {
            audioSource.volume = value;
        }
    }
}