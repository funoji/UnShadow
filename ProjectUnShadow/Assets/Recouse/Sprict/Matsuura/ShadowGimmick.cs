using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGimmick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // �Փˑ���̃I�u�W�F�N�g�� "sora" �^�O�����ꍇ
        if (other.CompareTag("sora"))
        {
            // �����ɓ����蔻�肪���������ۂ̏������L�q���܂�
            Debug.Log("sora �^�O�̃I�u�W�F�N�g�Ɠ�����܂���");
        }
    }
}
