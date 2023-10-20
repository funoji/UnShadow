using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    private AudioSource audioSource; // AudioSource���i�[����ϐ�
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera���Q�Ƃ��邽�߂̕ϐ�
    public bool K;//��]������t���O
    float count = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // ���̃X�N���v�g���A�^�b�`���ꂽ�Q�[���I�u�W�F�N�g��AudioSource���擾
        // virtualCamera��null�łȂ����Ƃ��m�F
        if (virtualCamera == null)
        {
            K = false;
            Debug.LogError("Cinemachine Virtual Camera���A�^�b�`����Ă��܂���B");
            return;
        }
    }

    private void Update()
    {
        // F�L�[�������ꂽ�Ƃ���Horizontal Axis��Value��ύX����
        if (Input.GetKeyDown(KeyCode.F) && count == 0)
        {
            { 
                K = true;
                PlaySwitchSound(); // ��]�����Đ�
            }
        }
           

        if (K == true)
        {
            // Cinemachine Virtual Camera��POV���擾
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal Axis��Value��ύX�i��: 90�x�j
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
            audioSource.Play(); // AudioSource�ɐݒ肳�ꂽ�I�[�f�B�I�N���b�v���Đ�
        }
    }
}