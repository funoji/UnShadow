using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

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
    }

    public void ResumeGame()
    {
        // �Q�[�����ĊJ����
        Time.timeScale = 1f;
        // �|�[�Y���j���[���\���ɂ���
        pauseMenuUI.SetActive(false);
    }
}
