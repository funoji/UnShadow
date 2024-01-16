using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSource���i�[����ϐ�
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera���Q�Ƃ��邽�߂̕ϐ�
    public bool L, R;//��]������t���O
    public float count;
    public float rotationSpeed = 9f;
    [SerializeField] GameObject[] Walls;
    int currentWall = 0;
    int nextwall = 0;
    public bool Canslide = true;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // ���̃X�N���v�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g��AudioSource���擾
        // virtualCamera��null�łȂ����Ƃ��m�F
        if (virtualCamera == null)
        {
            L = false;
            R = false;
            count = 0;
            Debug.LogError("Cinemachine Virtual Camera���A�^�b�`����Ă��܂���B");
            return;
        }
        Walls[currentWall].SetActive(false);

    }

    private void Update()
    {
        // F�L�[�������ꂽ�Ƃ���Horizontal Axis��Value��ύX����
        if (R == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) && count == 0 && Canslide)
            {
                L = true;
                HideWall(1);
                PlaySwitchSound(); // ��]�����Đ�
            }
            Revolution(ref L, 1);

        }



        if (L == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && count == 0 && Canslide)
            {
                R = true;
                HideWall(-1);
                PlaySwitchSound(); // ��]�����Đ�
            }
            Revolution(ref R, -1);
        }
    }
    private void PlaySwitchSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // AudioSource�ɐݒ肳�ꂽ�I�[�f�B�I�N���b�v���Đ�
        }
    }
    private void Revolution(ref bool Flag, int A)
    {
        if (Flag == true)
        {
            // Cinemachine Virtual Camera��POV���擾
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal Axis��Value��ύX�i��: 90�x�j
            pov.m_HorizontalAxis.Value += A * rotationSpeed;
            count += A * rotationSpeed;
            if (count >= 90 || count <= -90)
            {
                //Debug.Log("�J�E���g0");
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