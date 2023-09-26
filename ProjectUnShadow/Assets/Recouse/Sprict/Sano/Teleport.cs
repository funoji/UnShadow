using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject TeleportTargetObj;
    [SerializeField] float Tpduration;
    Vector3 targetPos;

    void Start()
    {
        // TeleportTargetObj の位置を targetPos に設定
        targetPos = TeleportTargetObj.transform.position;
        targetPos.y += 1; // 高さを調整
    }

    public Vector3 GetTpPos()
    {
        return targetPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 当たったオブジェクトのタグが "player" の場合
        if (collision.gameObject.CompareTag("Player"))
        {
            // コルーチンを開始して待機
            StartCoroutine(TeleportPlayer(collision.gameObject.GetComponent<Transform>()));
        }
    }

    private IEnumerator TeleportPlayer(Transform playerTransform)
    {
        // TPduration 秒間待機
        yield return new WaitForSeconds(Tpduration);

        // プレイヤーの位置を targetPos に設定
        playerTransform.position = targetPos;
    }
}