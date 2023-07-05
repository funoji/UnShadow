using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 1f;
    private bool isMoving = false;
    public float moveDistance = 1f; // 1�}�X�̈ړ�
    //x�������̓��͂�ۑ�
    private float _input_x;
    //z�������̓��͂�ۑ�
    private float _input_z;
    bool isrun;//�����Ă��邩���f
    public int PlayerHP = 100;
    bool canmove;
    int storedHi;
    int storedVi;
    [SerializeField] GameObject floorControllerOBJ;
    void Start()
    {
        animator = GetComponent<Animator>();
        int[][] StPos = floorControllerOBJ.GetComponent<FloorController>().StratPos();
        storedHi = StartPosDataHolder.StoredHi; // �v���W�F�N�gA�Ŋi�[����Hi�̒l���擾
        storedVi = StartPosDataHolder.StoredVi; // �v���W�F�N�gA�Ŋi�[����Vi�̒l���擾
        //Debug.Log(storedHi);
        //Debug.Log(storedVi);
        //canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
    }
    void Update()
    {
        ////x�������Az�������̓��͂��擾
        ////Horizontal�A�����A�������̃C���[�W
        //_input_x = Input.GetAxis("Horizontal");
        ////Vertical�A�����A�c�����̃C���[�W
        //_input_z = Input.GetAxis("Vertical");
        //var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        ////�ړ��̌����ȂǍ��W�֘A��Vector3�ň���
        //Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        ////�x�N�g���̌������擾
        //Vector3 direction = horizontalRotation * velocity.normalized;

        ////�ړ��������v�Z
        //float distance = moveDistance * Time.deltaTime;
        ////�ړ�����v�Z
        //Vector3 destination = transform.position + direction * distance;

        ////�ړ���Ɍ����ĉ�]
        //transform.LookAt(destination);

        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
                if (canmove)
                {
                    storedHi = PlayerPos.PlayertargetHori;
                    storedVi = PlayerPos.PlayertargetVer;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position + new Vector3(0f, 0f, moveDistance));
                }
    
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Down);
                if (canmove)
                {
                    storedHi = PlayerPos.PlayertargetHori;
                    storedVi = PlayerPos.PlayertargetVer;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position - new Vector3(0f, 0f, moveDistance));
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Left);
                if (canmove)
                {
                    storedHi = PlayerPos.PlayertargetHori;
                    storedVi = PlayerPos.PlayertargetVer;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position - new Vector3(moveDistance, 0f, 0f));
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Right);
                if (canmove)
                {
                    storedHi = PlayerPos.PlayertargetHori;
                    storedVi = PlayerPos.PlayertargetVer;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position + new Vector3(moveDistance, 0f, 0f));
                }
            }
        }
    }

    void TryMoveToPosition(Vector3 targetPosition)
    {
        // �ړ���ɏ�Q�������݂��Ȃ����`�F�b�N
        if (!IsObstacleInPosition(targetPosition))
        {
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    bool IsObstacleInPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.25f); // ��Q���̔��a�ɉ����Ē���
        foreach (Collider collider in colliders)
        {
            // ��Q���̃^�O�⃌�C���[���m�F���āA�ړ����u���b�N���邩�ǂ������肷�郍�W�b�N��ǉ�����
            if (collider.CompareTag("Box"))
            {
                return true;
            }
        }
        return false;
    }
    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
    public void TakeDamage(int damage)
    {
        PlayerHP -= damage;

        if (PlayerHP <= 0)
        {
            // �v���C���[�����S�����ꍇ�̏����������ɋL�q����
            // �Ⴆ�΁A�Q�[���I�[�o�[��ʂ�\������Ȃ�
        }
    }
}
