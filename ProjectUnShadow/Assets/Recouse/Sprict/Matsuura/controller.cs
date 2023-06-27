using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Animator animator;
    private float _speed = 3.0f;

    //x�������̓��͂�ۑ�
    private float _input_x;
    //z�������̓��͂�ۑ�
    private float _input_z;
    bool isrun;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //x�������Az�������̓��͂��擾
        //Horizontal�A�����A�������̃C���[�W
        _input_x = Input.GetAxis("Horizontal");
        //Vertical�A�����A�c�����̃C���[�W
        _input_z = Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        //�ړ��̌����ȂǍ��W�֘A��Vector3�ň���
        Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        //�x�N�g���̌������擾
        Vector3 direction = horizontalRotation * velocity.normalized;

        //�ړ��������v�Z
        float distance = _speed * Time.deltaTime;
        //�ړ�����v�Z
        Vector3 destination = transform.position + direction * distance;

        //�ړ���Ɍ����ĉ�]
        transform.LookAt(destination);
        //�ړ���̍��W��ݒ�
        transform.position = destination;

        if (Mathf.Abs(_input_x) < 0.1f && Mathf.Abs(_input_z) < 0.1f)
        {
            isrun = false;
            animator.SetBool("isrun", isrun);
        }
        else
        {
            isrun = true;
            animator.SetBool("isrun", isrun);
        }
    }
}
