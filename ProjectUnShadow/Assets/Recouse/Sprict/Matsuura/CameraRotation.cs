using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSourceを格納する変数
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Cameraを参照するための変数
    public bool L, R;//回転させるフラグ
    public float count;
    public float rotationSpeed = 9f;
    [SerializeField] GameObject[] Walls;
    int currentWall = 0;
    int nextwall = 0;
    public bool Canslide = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // このスクリプトがアタッチされたゲームオブジェクトのAudioSourceを取得
        // virtualCameraがnullでないことを確認
        if (virtualCamera == null)
        {
            L = false;
            R = false;
            count = 0;
            Debug.LogError("Cinemachine Virtual Cameraがアタッチされていません。");
            return;
        }
        Walls[currentWall].SetActive(false);

    }

    private void Update()
    {
        // Fキーが押されたときにHorizontal AxisのValueを変更する
        if (R == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) && count == 0 && Canslide)
            {
                L = true;
                HideWall(1);
                PlaySwitchSound(); // 回転音を再生
            }
            Revolution(ref L, 1);

        }



        if (L == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && count == 0 && Canslide)
            {
                R = true;
                HideWall(-1);
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
    private void Revolution(ref bool Flag, int A)
    {
        if (Flag == true)
        {
            // Cinemachine Virtual CameraのPOVを取得
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal AxisのValueを変更（例: 90度）
            pov.m_HorizontalAxis.Value += A * rotationSpeed;
            count += A * rotationSpeed;
            if (count >= 90 || count <= -90)
            {
                //Debug.Log("カウント0");
                Flag = false;
                count = 0;
            }
        }
    }
    void HideWall(int a)
    {
        Canslide = false;
        nextwall = a + currentWall;
        if (nextwall < 0) nextwall = 3;
        if (nextwall > 3) nextwall = 0;
        Walls[nextwall].SetActive(false);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds((float)0.1);
        Walls[currentWall].SetActive(true);
        currentWall = nextwall;
        Canslide = true;
    }
}