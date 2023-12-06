using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // 切り替えるライトの配列
    public testmove TestMove;
    private AudioSource switchSound; // AudioSourceを格納する変数
    public float lightcount;

    private int currentLightIndex = 0; // 現在有効なライトのインデックス
    public float animationSpeed = 0.5f; // アニメーションの速さ
    public float minIntensity = 50.0f; // 最小の明るさ
    public float maxIntensity = 200.0f; // 最大の明るさ
    private bool Changflag = true;

    private void Start()
    {
        switchSound = GetComponent<AudioSource>(); // "SwitchSound"という名前のゲームオブジェクトからAudioSourceを取得
    }

    private void Update()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[currentLightIndex].enabled)
            {
                // 増加または減少の判定
                if (Changflag)
                {
                    lights[currentLightIndex].intensity += Time.deltaTime * animationSpeed;
                    if (lights[currentLightIndex].intensity >= 200f)
                    {
                        lights[currentLightIndex].intensity = 200f;
                        Changflag = false;
                    }
                }
                else
                {
                    lights[currentLightIndex].intensity -= Time.deltaTime * animationSpeed;
                    if (lights[currentLightIndex].intensity <= 0.3f)
                    {
                        lights[currentLightIndex].intensity = 0.3f;
                        Changflag = true;
                    }
                }
            }
        }
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
