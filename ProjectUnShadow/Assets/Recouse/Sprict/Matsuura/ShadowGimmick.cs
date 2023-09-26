using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGimmick : MonoBehaviour
{
    private List<GameObject> taggedObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        // �Փˑ���̃I�u�W�F�N�g�� "sora" �^�O�����ꍇ
        if (other.CompareTag("sora"))
        {
            // �����ɓ����蔻�肪���������ۂ̏������L�q���܂�
            Debug.Log("sora �^�O�̃I�u�W�F�N�g�Ɠ�����܂���");
            SolarPanel scriptOnSoraObject = other.GetComponent<SolarPanel>();
            // �X�N���v�g���擾�ł������m�F
            if (scriptOnSoraObject != null)
            {
                // �X�N���v�g�̊֐����Ăяo��
                scriptOnSoraObject.OffBarrier();
            }
        }
    }
}
