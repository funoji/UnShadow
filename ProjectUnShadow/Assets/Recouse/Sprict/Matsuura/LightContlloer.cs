using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // 切り替えるライトの配列
    public testmove TestMove;
    private AudioSource switchSound; // AudioSourceを格納する変数
    public float lightcount;

    private int currentLightIndex = -1; // 現在有効なライトのインデックス

    private void Start()
    {
        switchSound = GetComponent<AudioSource>(); // "SwitchSound"という名前のゲームオブジェクトからAudioSourceを取得
        for(int i = 0; i < lights.Length; i++)
        {
            if (lights[i].enabled==true)
            {

            }
        }
    }

    private void Update()
    {
        if (lightcount > 0&&Time.timeScale==1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ToggleLight(TestMove.Up); // ライトのインデックスを指定して切り替える
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ToggleLight(TestMove.Right); // ライトのインデックスを指定して切り替える
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleLight(TestMove.Down); // ライトのインデックスを指定して切り替える
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ToggleLight(TestMove.Left); // ライトのインデックスを指定して切り替える
            }
        }
    }

    public void ToggleLight(int index)
    {

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[index].enabled)
            {
                return;
            }
        }
        if (index == currentLightIndex)
        {
            return; // 既に同じライトが有効になっている場合は何もしない
        }

        // ライトの切り替え処理
        for (int i = 0; i < lights.Length; i++)
        {
            if (i == index)
            {
                lights[i].enabled = true; // 指定したライトを有効にする
            }
            else
            {
                lights[i].enabled = false; // 他のライトを無効にする
            }
        }

        currentLightIndex = index; // 現在有効なライトのインデックスを更新

        PlaySwitchSound(); // ライトを切り替える際に音を再生
        lightcount--;
    }

    private void PlaySwitchSound()
    {
        if (switchSound != null && switchSound.clip != null)
        {
            switchSound.Play(); // AudioSourceに設定されたオーディオクリップを再生
        }
    }
}
