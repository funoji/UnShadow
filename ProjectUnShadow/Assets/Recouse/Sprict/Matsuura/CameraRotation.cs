using UnityEngine;
using Cinemachine;

public class CameraRotation : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera; // Cinemachine Virtual Camera���Q�Ƃ��邽�߂̕ϐ�
    public bool K;//��]������t���O
    float count = 0;

    private void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.F)&&count==0)
            K = true;

        if (K == true)
        {
            // Cinemachine Virtual Camera��POV���擾
            var pov = virtualCamera.GetCinemachineComponent<CinemachinePOV>();

            // Horizontal Axis��Value��ύX�i��: 90�x�j
            pov.m_HorizontalAxis.Value+=0.5f;
            count+=0.5f;
            if (count == 90)
            {
                K = false;
                count = 0;
            }
        }
        
    }
}