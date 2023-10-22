using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // �؂�ւ��郉�C�g�̔z��
    public testmove TestMove;
    private AudioSource switchSound; // AudioSource���i�[����ϐ�
    public float lightcount;

    private int currentLightIndex = -1; // ���ݗL���ȃ��C�g�̃C���f�b�N�X

    private void Start()
    {
        switchSound = GetComponent<AudioSource>(); // "SwitchSound"�Ƃ������O�̃Q�[���I�u�W�F�N�g����AudioSource���擾
        for(int i = 0; i < lights.Length; i++)
        {
            if (lights[i].enabled==true)
            {

            }
        }
    }

    private void Update()
    {
        if (lightcount > 0&&Time.timeScale==1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ToggleLight(TestMove.Up); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                ToggleLight(TestMove.Right); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ToggleLight(TestMove.Down); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                ToggleLight(TestMove.Left); // ���C�g�̃C���f�b�N�X���w�肵�Đ؂�ւ���
            }
        }
    }

    public void ToggleLight(int index)
    {

        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[index].enabled)
            {
                return;
            }
        }
        if (index == currentLightIndex)
        {
            return; // ���ɓ������C�g���L���ɂȂ��Ă���ꍇ�͉������Ȃ�
        }

        // ���C�g�̐؂�ւ�����
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

        currentLightIndex = index; // ���ݗL���ȃ��C�g�̃C���f�b�N�X���X�V

        PlaySwitchSound(); // ���C�g��؂�ւ���ۂɉ����Đ�
        lightcount--;
    }

    private void PlaySwitchSound()
    {
        if (switchSound != null && switchSound.clip != null)
        {
            switchSound.Play(); // AudioSource�ɐݒ肳�ꂽ�I�[�f�B�I�N���b�v���Đ�
        }
    }
}
