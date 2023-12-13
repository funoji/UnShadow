using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    FloorController _floorCon;
    int enemyPositionX;
    int enemyPositionZ;
    Vector3 moveDirection = Vector3.zero;
    Vector2Int enemypos;
    

    private void Start()
    {
        _floorCon = GameObject.Find("CreateStage").GetComponent<FloorController>();
        //Vector3 objectPosition = this.transform.position;

        enemyPositionX = _floorCon.GetScriptPos(GetComponentInParent<Floor>()).x;
        enemyPositionZ = _floorCon.GetScriptPos(GetComponentInParent<Floor>()).y;
    }
    public void MoveEnemy()
    {
        Debug.Log("MoveEnemy() called");

        bool moved = false;

        while (!moved)
        {
            FloorController.PlayerMovable randomDirection = (FloorController.PlayerMovable)UnityEngine.Random.Range(0, 4);

            (bool canMove, Vector2Int newPosition) = _floorCon.CanMove(enemyPositionX, enemyPositionZ, randomDirection);
            if (canMove)
            {
                enemyPositionX = newPosition.x;
                enemyPositionZ = newPosition.y;

                Vector2Int moveVector = FloorController.MoveVector[randomDirection];
                Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);
                transform.position += moveDirection;
                Debug.Log("Moved to: " + transform.position);
                moved = true; // à⁄ìÆê¨å˜
            }
        }
    }
}
