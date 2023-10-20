using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject DefaultUI;
    public GameObject DefaultUI2;
    public GameObject pauseMenuUI;
    public GameObject pauseMenuUI2;
    private AudioSource PauseSound;

    private void Start()
    {
        Time.timeScale = 1f;
        PauseSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        // ESC�L�[�������ꂽ��|�[�Y���j���[��\��/��\���ɂ���
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuUI.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        PlaypauseSound();
        // �Q�[�����ꎞ��~����
        Time.timeScale = 0f;
        // �|�[�Y���j���[��\������
        pauseMenuUI.SetActive(true);
        pauseMenuUI2.SetActive(true);
        DefaultUI.SetActive(false);
        DefaultUI2.SetActive(false);
    }

    public void ResumeGame()
    {
        PlaypauseSound();
        // �Q�[�����ĊJ����
        Time.timeScale = 1f;
        // �|�[�Y���j���[���\���ɂ���
        pauseMenuUI.SetActive(false);
        pauseMenuUI2.SetActive(false);
        DefaultUI.SetActive(true);
        DefaultUI2.SetActive(true);
    }
    private void PlaypauseSound()
    {
        if (PauseSound != null && PauseSound.clip != null)
        {
            PauseSound.Play(); // AudioSource�ɐݒ肳�ꂽ�I�[�f�B�I�N���b�v���Đ�
        }
    }
}
