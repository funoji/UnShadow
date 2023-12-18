using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBGetplayer : MonoBehaviour
{
    [SerializeField] MovebleBlock m_Move;
    [SerializeField] MovebleBlock.PushTo pushTo;
    private bool hasBeenCalled = false;
    testmove testmove;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasBeenCalled)
        {
            // トリガー内にプレイヤーが入ったときにフラグを立てる
            hasBeenCalled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        hasBeenCalled = false;
    }
    private void Update()
    {
        // フラグが立っているときにWキーが押されたら関数を呼ぶ
        if (hasBeenCalled && Input.GetKeyDown(KeyCode.W)&&testmove.isMoving==false)
        {
            m_Move.GetPlayerTouch(pushTo);
            hasBeenCalled = false; // フラグをリセットする
        }
    }
    private void Start()
    {
        testmove = GameObject.Find("player_rig3").GetComponent<testmove>();
    }
}
