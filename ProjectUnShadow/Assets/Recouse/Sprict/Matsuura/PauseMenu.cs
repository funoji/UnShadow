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
        // ESCキーが押されたらポーズメニューを表示/非表示にする
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
        // ゲームを一時停止する
        Time.timeScale = 0f;
        // ポーズメニューを表示する
        pauseMenuUI.SetActive(true);
        resumeMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        // ゲームを再開する
        Time.timeScale = 1f;
        // ポーズメニューを非表示にする
        pauseMenuUI.SetActive(false);
        resumeMenuUI.SetActive(false);
    }
}
