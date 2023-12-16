using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerToAudioSource : MonoBehaviour
{
    public AudioMixer audioMixer;   // Audio Mixer���Q�Ƃ��邽�߂̕ϐ�
    public AudioSource BGM_audioSource; // Audio Source���Q�Ƃ��邽�߂̕ϐ�
    public AudioSource[] SE_audioSource;


    void Start()
    {
       
    }
    private void Update()
    {
        // �������ʂ̐ݒ�iAudio Mixer�̏����l��Audio Source�ɔ��f�j
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
        // �X���C�_�[�̒l��Audio Mixer�ɔ��f
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 60);

        // Audio Mixer�̒l��Audio Source�ɔ��f
        BGM_audioSource.volume = volume;
    }
}