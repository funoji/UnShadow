using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 1f;
    private bool isMoving = false;
    public float moveDistance = 1f; // 1マスの移動
    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;
    bool isrun;//動いているか判断
    public int PlayerHP = 100;
    bool canmove;
    int storedHi;
    int storedVi;
    [SerializeField] GameObject floorControllerOBJ;
    void Start()
    {
        animator = GetComponent<Animator>();
        int[][] StPos = floorControllerOBJ.GetComponent<FloorController>().StratPos();
        storedHi = StartPosDataHolder.StoredHi; // プロジェクトAで格納したHiの値を取得
        storedVi = StartPosDataHolder.StoredVi; // プロジェクトAで格納したViの値を取得
        //Debug.Log(storedHi);
        //Debug.Log(storedVi);
        //canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
    }
    void Update()
    {
        ////x軸方向、z軸方向の入力を取得
        ////Horizontal、水平、横方向のイメージ
        //_input_x = Input.GetAxis("Horizontal");
        ////Vertical、垂直、縦方向のイメージ
        //_input_z = Input.GetAxis("Vertical");
        //var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

        ////移動の向きなど座標関連はVector3で扱う
        //Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        ////ベクトルの向きを取得
        //Vector3 direction = horizontalRotation * velocity.normalized;

        ////移動距離を計算
        //float distance = moveDistance * Time.deltaTime;
        ////移動先を計算
        //Vector3 destination = transform.position + direction * distance;

        ////移動先に向けて回転
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
