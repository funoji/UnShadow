using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testmove : MonoBehaviour
{
    private AudioSource audioSource; // AudioSourceを格納する変数
    Animator animator;
    public float moveSpeed = 1f;
    private bool isMoving = false;
    Vector3 moveDistanceForward, moveDistanceRight; // 1マスの移動
    //x軸方向の入力を保存
    private float _input_x;
    //z軸方向の入力を保存
    private float _input_z;
    bool isrun;
    public int PlayerHP = 10;
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
    public int Up = 0,
        Right = 1,
        Down = 2,
        Left = 3;

    public CameraRotation Rotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCameraTransform = Camera.main.transform;
        animator = GetComponent<Animator>();
        moveDistanceForward = new Vector3(0, 0, 1);
        moveDistanceRight = new Vector3(1, 0, 0);
        storedHi = floorControllerOBJ.GetComponent<FloorController>().StratPos().x; // プロジェクトAで格納したHiの値を取得
        storedVi = floorControllerOBJ.GetComponent<FloorController>().StratPos().y; // プロジェクトAで格納したViの値を取得
        Debug.Log(storedHi);
        Debug.Log(storedVi);
        _floorController = floorControllerOBJ.GetComponent<FloorController>();
        audioSource = GetComponent<AudioSource>(); // このスクリプトがアタッチされたゲームオブジェクトのAudioSourceを取得
        //canmove = floorControllerOBJ.GetComponent<FloorController>().CanMove(storedHi, storedVi, FloorController.PlayerMovable.Up);
    }
    void Update()
    {
        if (!isMoving)
        {
            // カメラの正面方向を取得
            Vector3 cameraForward = mainCameraTransform.forward;
            Vector3 cameraRight = mainCameraTransform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
            // 移動ベクトルをカメラの正面方向に固定
            Vector3 moveVectorForward = cameraForward;
            Vector3 moveVectorRight = cameraRight;

            if (Input.GetKeyDown(KeyCode.W))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Up).Item2;
                if (canmove)
                {
                    if (cameraForward != Vector3.zero)//動く方向に回転
                        transform.rotation = Quaternion.LookRotation(-cameraForward);
                    destinationPositionForward = transform.position + moveVectorForward;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    Debug.Log(destinationPositionForward);
                    TryMoveToPosition(destinationPositionForward);
                    PlaySwitchSound(); // 足音を再生
                }

            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Down).Item2;
                if (canmove)
                {
                    if (cameraForward != Vector3.zero)//動く方向に回転
                        transform.rotation = Quaternion.LookRotation(cameraForward);
                    destinationPositionBag = transform.position - moveVectorForward;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionBag);
                    PlaySwitchSound(); // 足音を再生
                }

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Left).Item2;
                if (canmove)
                {
                    if (cameraRight != Vector3.zero)//動く方向に回転
                        transform.rotation = Quaternion.LookRotation(cameraRight);

                    destinationPositionLeft = transform.position - moveVectorRight;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionLeft);
                    PlaySwitchSound(); // 足音を再生
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                canmove = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item1;
                PlayerPos = _floorController.CanMove(storedHi, storedVi, (FloorController.PlayerMovable)Right).Item2;
                if (canmove)
                {
                    if (cameraRight != Vector3.zero)//動く方向に回転
                        transform.rotation = Quaternion.LookRotation(-cameraRight);

                    destinationPositionRight = transform.position + moveVectorRight;
                    storedHi = PlayerPos.x;
                    storedVi = PlayerPos.y;
                    Debug.Log(storedHi);
                    Debug.Log(storedVi);
                    TryMoveToPosition(destinationPositionRight);
                    PlaySwitchSound(); // 足音を再生
                }
            }
            
        }

        if (Rotation.L == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
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
        if(Rotation.R==false)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                Up = Up - 1;
                Right = Right - 1;
                Down = Down - 1;
                Left = Left - 1;
                Debug.Log(Up);
                if (Up == -1)
                    Up = 3;
                if (Right == -1)
                    Right = 3;
                if (Down == -1)
                    Down = 3;
                if (Left == -1)
                    Left = 3;
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
        // アニメーション再生開始
        animator.SetBool("Walking", true);
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        // 移動が完了したらアニメーションを停止する
        animator.SetBool("Walking", false);

        isMoving = false;
    }
    public void TakeDamage(int damage)
    {
        PlayerHP -= damage;

        if (PlayerHP == 0)
        {
            // プレイヤーが死亡した場合の処理をここに記述する
            // 例えば、ゲームオーバー画面を表示するなど
            SceneManager.LoadScene("Matsutake_Retry");
        }
    }
    private void PlaySwitchSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play(); // AudioSourceに設定されたオーディオクリップを再生
        }
    }
}
