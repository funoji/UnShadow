using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerToAudioSource : MonoBehaviour
{
    public AudioMixer audioMixer;   // Audio Mixerを参照するための変数
    public AudioSource BGM_audioSource; // Audio Sourceを参照するための変数
    public AudioSource[] SE_audioSource;


    void Start()
    {
       
    }
    private void Update()
    {
        // 初期音量の設定（Audio Mixerの初期値をAudio Sourceに反映）
        float BGMinitialVolume;
        audioMixer.GetFloat("BGM_Volume", out BGMinitialVolume);
        BGM_audioSource.volume = Mathf.Pow(10, BGMinitialVolume / 60);

        float SEinitialVolume;
        audioMixer.GetFloat("SE_Volume", out SEinitialVolume);
        for (int i = 0; i < SE_audioSource.Length; i++)
        {
            SE_audioSource[i].volume = Mathf.Pow(10, SEinitialVolume / 60);
        }
    }

    public void SetVolume(float volume)
    {
        // スライダーの値をAudio Mixerに反映
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 60);

        // Audio Mixerの値をAudio Sourceに反映
        BGM_audioSource.volume = volume;
    }
}