using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSourceを格納する変数
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Cameraを参照するための変数
    public bool L,R;//回転させるフラグ
    float count = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // このスクリプトがアタッチされたゲームオブジェクトのAudioSourceを取得
        // virtualCameraがnullでないことを確認
        if (virtualCamera == null)
        {
            L = false;
            R = false;
            Debug.LogError("Cinemachine Virtual Cameraがアタッチされていません。");
            return;
        }
    }

    private void Update()
    {
        // Fキーが押されたときにHorizontal AxisのValueを変更する
        if (R == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && count == 0)
            {
                L = true;
                PlaySwitchSound(); // 回転音を再生
            }
            Revolution(ref L,1);
        }
        
        

        if (L == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) && count == 0)
            {
                R = true;
                PlaySwitchSound(); // 回転音を再生
            }
            Revolution(ref R, -1);
        }
    }
    private void PlaySwitchSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // AudioSourceに設定されたオーディオクリップを再生
        }
    }
    private void Revolution(ref bool Flag,int A)
    {
        if (Flag == true)
        {
            // Cinemachine Virtual CameraのPOVを取得
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal AxisのValueを変更（例: 90度）
            pov.m_HorizontalAxis.Value += A;
            count += A;
            if (count == 90||count==-90)
            {
                Flag = false;
                count = 0;
            }
        }
    }
}