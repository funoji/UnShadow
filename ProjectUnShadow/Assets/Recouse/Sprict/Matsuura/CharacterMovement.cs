using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 1f;
    private bool isMoving = false;
    Vector3 moveDistanceForward, moveDistanceRight; // 1マスの移動
    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;
    bool isrun;
    public int PlayerHP = 100;
    bool canmove;
    private Vector2Int PlayerPos;
    public int storedHi;
    public int storedVi;
    FloorController _floorController;
    [SerializeField] GameObject floorControllerOBJ;
    public int Up = 0,
        Left = 1,
        Down = 2,
        Right = 3;

    void Start()
    {
        animator = GetComponent<Animator>();
        moveDistanceForward = new Vector3(0, 0, 1);
        moveDistanceRight = new Vector3(1, 0, 0);
        storedHi = floorControllerOBJ.GetComponent<FloorController>().StratPos().x; // プロジェクトAで格納したHiの値を取得
        storedVi = floorControllerOBJ.GetComponent<FloorController>().StratPos().y; // プロジェクトAで格納したViの値を取得
        Debug.Log(storedHi);
        Debug.Log(storedVi);
        _floorController = floorControllerOBJ.GetComponent<FloorController>();
        //canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
    }
    void Update()
    {
        if (!isMoving)
        {
 
            if (Input.GetKeyDown(KeyCode.W))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item2;
                if (canmove)
                {
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position + moveDistanceForward);
                }

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item2;
                if (canmove)
                {
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position - moveDistanceForward);
                }

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item2;
                if (canmove)
                {
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position - moveDistanceRight);
                }

            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item2;
                if (canmove)
                {
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(transform.position + moveDistanceRight);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Up = Up + 1;
            Left = Left + 1;
            Down = Down + 1;
            Right = Down + 1;
            Debug.Log(Up);
        }
    }

    void TryMoveToPosition(Vector3 targetPosition)
    {
        // 移動先に障害物が存在しないかチェック
        if (!IsObstacleInPosition(targetPosition))
        {
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }
    bool IsObstacleInPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.25f); // 障害物の半径に応じて調整
        foreach (Collider collider in colliders)
        {
            // 障害物のタグやレイヤーを確認して、移動をブロックするかどうか判定するロジックを追加する
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
            // プレイヤーが死亡した場合の処理をここに記述する
            // 例えば、ゲームオーバー画面を表示するなど
        }
    }
}
