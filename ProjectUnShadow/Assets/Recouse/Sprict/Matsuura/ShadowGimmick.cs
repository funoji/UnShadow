using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGimmick : MonoBehaviour
{
    private List<GameObject> taggedObjects = new List<GameObject>();
    SolarPanel scriptOnSoraObject;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // �Փˑ���̃I�u�W�F�N�g�� "sora" �^�O�����ꍇ
        if (other.CompareTag("sora"))
        {
            // �����ɓ����蔻�肪���������ۂ̏������L�q���܂�
            Debug.Log("sora �^�O�̃I�u�W�F�N�g�Ɠ�����܂���");
            scriptOnSoraObject = other.GetComponent<SolarPanel>();
            // �X�N���v�g���擾�ł������m�F
            if (scriptOnSoraObject != null)
            {
                // �X�N���v�g�̊֐����Ăяo��
                scriptOnSoraObject.OffBarrier();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sora"))
        {
            scriptOnSoraObject.OnBarrier();
        }
    }
    private void OnDestroy()
    {
        // ���̃X�N���v�g���A�^�b�`���Ă���I�u�W�F�N�g���폜���ꂽ�ۂ̏���
        Debug.Log("���̃I�u�W�F�N�g���폜����܂���");

        // scriptOnSoraObject��null�łȂ��ꍇ�AOnBarrier���Ăяo��
        if (scriptOnSoraObject != null)
        {
            scriptOnSoraObject.OnBarrier();
        }
    }
}
