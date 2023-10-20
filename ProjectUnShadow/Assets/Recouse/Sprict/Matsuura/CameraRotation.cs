using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSourceを格納する変数
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Cameraを参照するための変数
    public bool K;//回転させるフラグ
    float count = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // このスクリプトがアタッチされたゲームオブジェクトのAudioSourceを取得
        // virtualCameraがnullでないことを確認
        if (virtualCamera == null)
        {
            K = false;
            Debug.LogError("Cinemachine Virtual Cameraがアタッチされていません。");
            return;
        }
    }

    private void Update()
    {
        // Fキーが押されたときにHorizontal AxisのValueを変更する
        if (Input.GetKeyDown(KeyCode.F) && count == 0)
        {
            { 
                K = true;
                PlaySwitchSound(); // 回転音を再生
            }
        }
           

        if (K == true)
        {
            // Cinemachine Virtual CameraのPOVを取得
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal AxisのValueを変更（例: 90度）
            pov.m_HorizontalAxis.Value+=1f;
            count+=1f;
            if (count == 90)
            {
                K = false;
                count = 0;
            }
        }
        
    }
    private void PlaySwitchSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // AudioSourceに設定されたオーディオクリップを再生
        }
    }
}