using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // 切り替えるライトの配列
    public testmove TestMove;
    private AudioSource switchSound; // AudioSourceを格納する変数

    private void Start()
    {
        switchSound = GameObject.Find("SE_Audio").GetComponent<AudioSource>(); // "SwitchSound"という名前のゲームオブジェクトからAudioSourceを取得
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ToggleLight(TestMove.Up); // ライトのインデックスを指定して切り替える
            PlaySwitchSound(); // ライトを切り替える際に音を再生
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleLight(TestMove.Right); // ライトのインデックスを指定して切り替える
            PlaySwitchSound(); // ライトを切り替える際に音を再生
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleLight(TestMove.Down); // ライトのインデックスを指定して切り替える
            PlaySwitchSound(); // ライトを切り替える際に音を再生
        }
       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleLight(TestMove.Left); // ライトのインデックスを指定して切り替える
            PlaySwitchSound(); // ライトを切り替える際に音を再生
        }
    }

    public void ToggleLight(int index)
    {
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
    }

    private void PlaySwitchSound()
    {
        if (switchSound != null && switchSound.clip != null)
        {
            switchSound.Play(); // AudioSourceに設定されたオーディオクリップを再生
        }
    }
}
