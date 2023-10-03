using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Cameraを参照するための変数

    private void Start()
    {
        // virtualCameraがnullでないことを確認
        if (virtualCamera == null)
        {
            Debug.LogError("Cinemachine Virtual Cameraがアタッチされていません。");
            return;
        }
    }

    private void Update()
    {
        // Fキーが押されたときにHorizontal AxisのValueを変更する
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Cinemachine Virtual CameraのPOVを取得
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal AxisのValueを変更（例: 90度）
            pov.m_HorizontalAxis.Value += 90f;
        }
    }
}