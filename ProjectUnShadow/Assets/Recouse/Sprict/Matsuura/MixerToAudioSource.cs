using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerToAudioSource : MonoBehaviour
{
    public AudioMixer audioMixer;   // Audio Mixer���Q�Ƃ��邽�߂̕ϐ�
    public AudioSource audioSource; // Audio Source���Q�Ƃ��邽�߂̕ϐ�

    void Start()
    {
        // �������ʂ̐ݒ�iAudio Mixer�̏����l��Audio Source�ɔ��f�j
        float initialVolume;
        audioMixer.GetFloat("BGM_Volume", out initialVolume);
        audioSource.volume = Mathf.Pow(10, initialVolume / 20);
    }

    public void SetVolume(float volume)
    {
        // �X���C�_�[�̒l��Audio Mixer�ɔ��f
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);

        // Audio Mixer�̒l��Audio Source�ɔ��f
        audioSource.volume = volume;
    }
}