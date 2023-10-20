using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject resumeMenuUI;

    private void Start()
    {
        Time.timeScale = 1f;
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
        // �Q�[�����ꎞ��~����
        Time.timeScale = 0f;
        // �|�[�Y���j���[��\������
        pauseMenuUI.SetActive(true);
        resumeMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        // �Q�[�����ĊJ����
        Time.timeScale = 1f;
        // �|�[�Y���j���[���\���ɂ���
        pauseMenuUI.SetActive(false);
        resumeMenuUI.SetActive(false);
    }
}
