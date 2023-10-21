using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSource���i�[����ϐ�
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera���Q�Ƃ��邽�߂̕ϐ�
    public bool L,R;//��]������t���O
    float count = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // ���̃X�N���v�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g��AudioSource���擾
        // virtualCamera��null�łȂ����Ƃ��m�F
        if (virtualCamera == null)
        {
            L = false;
            R = false;
            Debug.LogError("Cinemachine Virtual Camera���A�^�b�`����Ă��܂���B");
            return;
        }
    }

    private void Update()
    {
        // F�L�[�������ꂽ�Ƃ���Horizontal Axis��Value��ύX����
        if (R == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && count == 0)
            {
                L = true;
                PlaySwitchSound(); // ��]�����Đ�
            }
            Revolution(ref L,1);
        }
        
        

        if (L == false)
        {
            if (Input.GetKeyDown(KeyCode.Q) && count == 0)
            {
                R = true;
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
    private void Revolution(ref bool Flag,int A)
    {
        if (Flag == true)
        {
            // Cinemachine Virtual Camera��POV���擾
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal Axis��Value��ύX�i��: 90�x�j
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