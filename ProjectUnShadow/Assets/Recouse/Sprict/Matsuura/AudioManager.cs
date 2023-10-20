using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer masterMixer;  // マスターミキサーへの参照
    public Slider volumeSlider;     // UIのスライダーへの参照

    // 初期化
    void Start()
    {
        // スライダーの値をマスターミキサーのパラメータに設定
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0.75f); // デフォルトの音量
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume); // 初期音量を設定
    }

    // スライダーの値が変更されたときに呼ばれるメソッド
    public void SetVolume(float volume)
    {
        // マスターミキサーのパラメータを変更
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        // 現在の音量を保存
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
