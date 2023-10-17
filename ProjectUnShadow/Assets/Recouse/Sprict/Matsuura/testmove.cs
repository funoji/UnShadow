using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 1f;
    private bool isMoving = false;
    Vector3 moveDistanceForward, moveDistanceRight; // 1�}�X�̈ړ�
    //x�������̓��͂�ۑ�
    private float _input_x;
    //z�������̓��͂�ۑ�
    private float _input_z;
    bool isrun;
    public int PlayerHP = 100;
    bool canmove;
    private Vector2Int PlayerPos;
    public int storedHi;
    public int storedVi;
    FloorController _floorController;
    [SerializeField] GameObject floorControllerOBJ;
    private Rigidbody rb;
    private Transform mainCameraTransform;
    private Vector3 destinationPositionForward;
    private Vector3 destinationPositionBag;
    private Vector3 destinationPositionRight;
    private Vector3 destinationPositionLeft;
    int Up = 0,
        Right = 1,
        Down = 2,
        Left = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
        moveDistanceForward = new Vector3(0, 0, 1);
        moveDistanceRight = new Vector3(1, 0, 0);
        storedHi = floorControllerOBJ.GetComponent<FloorController>().StratPos().x; // �v���W�F�N�gA�Ŋi�[����Hi�̒l���擾
        storedVi = floorControllerOBJ.GetComponent<FloorController>().StratPos().y; // �v���W�F�N�gA�Ŋi�[����Vi�̒l���擾
        Debug.Log(storedHi);
        Debug.Log(storedVi);
        _floorController = floorControllerOBJ.GetComponent<FloorController>();
        //canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
    }
    void Update()
    {
        if (!isMoving)
        {
            // �J�����̐��ʕ������擾
            Vector3 cameraForward = mainCameraTransform.forward;
            Vector3 cameraRight = mainCameraTransform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
            // �ړ��x�N�g�����J�����̐��ʕ����ɌŒ�
            Vector3 moveVectorForward = cameraForward;
            Vector3 moveVectorRight = cameraRight;

            

            if (Input.GetKeyDown(KeyCode.W))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item2;
                if (canmove)
                {
                    destinationPositionForward = transform.position + moveVectorForward;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    Debug.Log(destinationPositionForward);
                    TryMoveToPosition(destinationPositionForward);
                }

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item2;
                if (canmove)
                {
                    destinationPositionBag = transform.position - moveVectorForward;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionBag);
                }

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item2;
                if (canmove)
                {
                    destinationPositionLeft = transform.position - moveVectorRight;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionLeft);
                }

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item2;
                if (canmove)
                {
                    destinationPositionRight = transform.position + moveVectorRight;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionRight);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            Up = Up + 1;
            Right = Right + 1;
            Down = Down + 1;
            Left = Left + 1;
            Debug.Log(Up);
            if (Up == 4)
                Up = 0;
            if (Right == 4)
                Right = 0;
            if (Down == 4)
                Down = 0;
            if (Left == 4)
                Left = 0;
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
