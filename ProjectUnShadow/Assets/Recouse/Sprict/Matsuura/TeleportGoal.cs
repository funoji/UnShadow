using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGoal : MonoBehaviour
{
    [SerializeField] CharacterMovement characterMovement;
    [SerializeField] GameObject FloorControllObj;
    Floor thisFloor;
    FloorController _Controller;
    Vector2Int PlayerPos;

    void Start()
    {
        thisFloor = this.GetComponent<Floor>();
        _Controller = FloorControllObj.GetComponent<FloorController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 当たったオブジェクトのタグが "player" の場合
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPos = _Controller.GetScriptPos(thisFloor);
            characterMovement.storedHi = PlayerPos.x;
            characterMovement.storedVi = PlayerPos.y;
            Debug.Log(characterMovement.storedHi);
            Debug.Log(characterMovement.storedVi);
        }
    }
}
