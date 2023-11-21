using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerToAudioSource : MonoBehaviour
{
    public AudioMixer audioMixer;   // Audio Mixerを参照するための変数
    public AudioSource audioSource; // Audio Sourceを参照するための変数

    void Start()
    {
        // 初期音量の設定（Audio Mixerの初期値をAudio Sourceに反映）
        float initialVolume;
        audioMixer.GetFloat("BGM_Volume", out initialVolume);
        audioSource.volume = Mathf.Pow(10, initialVolume / 20);
    }

    public void SetVolume(float volume)
    {
        // スライダーの値をAudio Mixerに反映
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        // Audio Mixerの値をAudio Sourceに反映
        audioSource.volume = volume;
    }
}