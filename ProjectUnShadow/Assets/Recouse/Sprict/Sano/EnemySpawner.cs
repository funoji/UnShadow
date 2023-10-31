using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject EnemyObj;

    private void Awake()
    {
        Vector3 target = transform.position;
        target.y += 1;
        GameObject enemy = Instantiate(EnemyObj, transform);
        enemy.transform.localPosition = new Vector3(0, 1, 0);
    }
}