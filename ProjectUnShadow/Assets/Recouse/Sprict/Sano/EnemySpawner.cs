using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyObj;
    [SerializeField] private GameObject FloorControllerObj;
    FloorController _floorController;
    bool isEnemyMovable;
    Vector2Int enemyPosition;

    private void Start()
    {
        _floorController =FloorControllerObj.GetComponent<FloorController>();
        this.GetComponent<>
    }
    // Start is called before the first frame update
    void MoveEmeny()
    {
        isEnemyMovable = _floorController.CanMove();
    }

   void SpawnEnemy(GameObject EObj)
    {
        Vector3 Target = this.GetComponent<Vector3>();
        Target.y += 1;
        Instantiate(EObj,Target,Quaternion.identity);
    }
}
