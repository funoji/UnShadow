using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGoal : MonoBehaviour
{
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
        // ���������I�u�W�F�N�g�̃^�O�� "player" �̏ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPos = _Controller.GetScriptPos(thisFloor);
            Debug.Log(PlayerPos);
        }
    }
}
