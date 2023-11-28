using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPrefabs : MonoBehaviour
{
    [SerializeField] GameObject _Normalfloor;
    public GameObject NormalFloorObj => _Normalfloor;
    [SerializeField] GameObject _StartObj;
    public GameObject StartFloorObj => _StartObj;
    [SerializeField] GameObject _GoalFloor;
    public GameObject GoalFloorObj => _GoalFloor;
    [SerializeField] GameObject _FristHeight;
    public GameObject FirstHeight => _FristHeight;
    [SerializeField] GameObject _SecondHeight;
    public GameObject SecondHeight => _SecondHeight;
    [SerializeField] GameObject _ThirdHeight;
    public GameObject ThirdHeight => _ThirdHeight;
    [SerializeField] GameObject _SolarPanel;
    public GameObject SolarPanel => _SolarPanel;
    [SerializeField] GameObject _Sponar;
    public GameObject EnemySponar => _Sponar;
    [SerializeField] GameObject _ShadowCreat;
    public GameObject ShadowCreat => _ShadowCreat;
    [SerializeField] GameObject _Bariier;
    public GameObject Bariier => _Bariier;
    [SerializeField] GameObject _Teleport;
    public GameObject Teleport => _Teleport;
    [SerializeField] GameObject _TeleportGoal;
    public GameObject TeleportGoal => _TeleportGoal;
    [SerializeField] GameObject _MoveBlock;
    public GameObject MoveBlock => _MoveBlock;
}
