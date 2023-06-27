using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // �؂�ւ��郉�C�g�̔z��

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ToggleLight(0); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleLight(1); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleLight(2); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleLight(3); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
        }
    }

    public void ToggleLight(int index)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (i == index)
            {
                lights[i].enabled = true; // �w�肵�����C�g��L���ɂ���
            }
            else
            {
                lights[i].enabled = false; // ���̃��C�g�𖳌��ɂ���
            }
        }
    }
}
