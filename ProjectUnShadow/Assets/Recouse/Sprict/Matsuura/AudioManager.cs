using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;  // �}�X�^�[�~�L�T�[�ւ̎Q��
    public Slider volumeSlider;     // UI�̃X���C�_�[�ւ̎Q��

    // ������
    void Start()
    {
        // �X���C�_�[�̒l���}�X�^�[�~�L�T�[�̃p�����[�^�ɐݒ�
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f); // �f�t�H���g�̉���
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume); // �������ʂ�ݒ�
    }

    // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void SetVolume(float volume)
    {
        // �}�X�^�[�~�L�T�[�̃p�����[�^��ύX
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        // ���݂̉��ʂ�ۑ�
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
