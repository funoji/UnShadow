using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // �؂�ւ��郉�C�g�̔z��
    public testmove TestMove;
    private AudioSource switchSound; // AudioSource���i�[����ϐ�

    private void Start()
    {
        switchSound = GameObject.Find("SE_Audio").GetComponent<AudioSource>(); // "SwitchSound"�Ƃ������O�̃Q�[���I�u�W�F�N�g����AudioSource���擾
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ToggleLight(TestMove.Up); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            PlaySwitchSound(); // ���C�g��؂�ւ���ۂɉ����Đ�
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleLight(TestMove.Right); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            PlaySwitchSound(); // ���C�g��؂�ւ���ۂɉ����Đ�
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleLight(TestMove.Down); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            PlaySwitchSound(); // ���C�g��؂�ւ���ۂɉ����Đ�
        }
       
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleLight(TestMove.Left); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            PlaySwitchSound(); // ���C�g��؂�ւ���ۂɉ����Đ�
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

    private void PlaySwitchSound()
    {
        if (switchSound != null && switchSound.clip != null)
        {
            switchSound.Play(); // AudioSource�ɐݒ肳�ꂽ�I�[�f�B�I�N���b�v���Đ�
        }
    }
}
