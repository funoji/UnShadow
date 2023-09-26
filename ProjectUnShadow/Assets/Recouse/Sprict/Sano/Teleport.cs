    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Teleport : MonoBehaviour
    {
        [SerializeField] GameObject TeleportTargetObj;
        [SerializeField] float Tpduration;
        [SerializeField] GameObject FloorControllObj;
        Vector3 targetPos;
        Floor thisFloor;
        FloorController _Controller;
        Vector2Int PlayerPos;

        void Start()
        {
            // TeleportTargetObj の位置を targetPos に設定
            targetPos = TeleportTargetObj.transform.position;
            targetPos.y += 1; // 高さを調整
            thisFloor = this.GetComponent<Floor>();
            _Controller = FloorControllObj.GetComponent<FloorController>();
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
                PlayerPos =_Controller.GetScriptPos(thisFloor);
                Debug.Log(PlayerPos);
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