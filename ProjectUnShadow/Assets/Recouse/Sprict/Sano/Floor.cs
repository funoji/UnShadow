using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Floor : MonoBehaviour
{
    [SerializeField] FloorPrefabs floorPrefabs;
    [SerializeField] private GameObject MoveBlockPrefab;


    public enum FloorRoles
    {
        NULL,
        Normal,
        Start,
        Goal,
        FirstHeight,
        SecondHeight,
        ThirdHeight,
        SolarPanel,
        EnemySponer,
        Barrier,
        Teleport,
        TeleportGoal,
        MoveableBlock,
    }
    [SerializeField] private FloorRoles Roles = FloorRoles.NULL;

    public enum MoveStatus
    { CanStep,CantStep }
    [SerializeField] private MoveStatus moveStatus;
    public enum shadowblock
    { Unshadow,Shadow }
    [SerializeField] private shadowblock Shadowblock;

    private void Reset()
    {
        floorPrefabs = GameObject.Find("CreateStage").GetComponent<FloorPrefabs>();
    }
    public FloorRoles GetRoles()
    {
        return Roles;
    }
    public MoveStatus GetMoveStatus()
    {

        return moveStatus;
    }
    public void SetRole(FloorRoles Newroles)
    {
        Debug.Log("ここまできてる");
        GetComponent<Floor>().Roles = Newroles;
    }
    public void SetMoveStatus(MoveStatus newSt)
    {
        moveStatus = newSt;
    }

    public void SetShadow(shadowblock set)
    {
        Shadowblock = set;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Floor))]
    class ChangeFloors : Editor
    {
        FloorRoles currentRole;
        Floor floor;
        [SerializeField] GameObject CreateObj;
        private Dictionary<FloorRoles, GameObject> prefabDictionary = new Dictionary<FloorRoles, GameObject>();
        [SerializeField] GameObject Moveblock;

        private void OnEnable()
        {
            floor = (Floor)target;
            floor.floorPrefabs = GameObject.Find("CreateStage").GetComponent<FloorPrefabs>();
            CreateObj = GameObject.Find("CreateStage");

            // �v���n�u���f�B�N�V���i���ɒǉ�
            //�V�����I�u�W�F�N�g��ǉ�����ꍇ prefabDictionary.Add(FloorRoles.�Z�Z, floor.floorPrefabs.�Z�Z);�Ƃ��Ă��������B
            prefabDictionary.Clear();
            prefabDictionary.Add(FloorRoles.Normal, floor.floorPrefabs.NormalFloorObj);
            prefabDictionary.Add(FloorRoles.Start, floor.floorPrefabs.StartFloorObj);
            prefabDictionary.Add(FloorRoles.Goal, floor.floorPrefabs.GoalFloorObj);
            prefabDictionary.Add(FloorRoles.FirstHeight, floor.floorPrefabs.FirstHeight);
            prefabDictionary.Add(FloorRoles.SecondHeight, floor.floorPrefabs.SecondHeight);
            prefabDictionary.Add(FloorRoles.ThirdHeight, floor.floorPrefabs.ThirdHeight);
            prefabDictionary.Add(FloorRoles.SolarPanel, floor.floorPrefabs.SolarPanel);
            prefabDictionary.Add(FloorRoles.EnemySponer, floor.floorPrefabs.EnemySponar);
            //prefabDictionary.Add(FloorRoles.Shadow, floor.floorPrefabs.ShadowCreat);
            prefabDictionary.Add(FloorRoles.Barrier, floor.floorPrefabs.Bariier);
            prefabDictionary.Add(FloorRoles.Teleport, floor.floorPrefabs.Teleport);
            prefabDictionary.Add(FloorRoles.TeleportGoal, floor.floorPrefabs.TeleportGoal);
            prefabDictionary.Add(FloorRoles.MoveableBlock, floor.floorPrefabs.MoveBlock);
        }

        void ChangeShape()
        {
            EditorGUI.BeginChangeCheck();
            UnityEditor.SerializedProperty RoleProperty = serializedObject.FindProperty("Roles");
            UnityEditor.SerializedProperty MoveProperty = serializedObject.FindProperty("moveStatus");
            UnityEditor.SerializedProperty ShadowProperty = serializedObject.FindProperty("Shadowblock");
            EditorGUILayout.PropertyField(RoleProperty);
            EditorGUILayout.PropertyField(MoveProperty);
            EditorGUILayout.PropertyField(ShadowProperty);
            currentRole = (FloorRoles)RoleProperty.enumValueIndex;
            GameObject NewFloor;
            //Role��prefab���擾�ł��Ă��邩�m�F
            if (prefabDictionary.TryGetValue(currentRole, out GameObject create))
            {
                //�擾�ł��Ă����ꍇ
                if (EditorGUI.EndChangeCheck())
                {
                    //�C���X�^���X��
                    NewFloor = GameObject.Instantiate(create, floor.transform.position, Quaternion.identity);
                    if (CreateObj)
                    {
                        //�q�I�u�W�F�N�g�Ɋi�[
                        NewFloor.transform.parent = CreateObj.transform;
                        //�w��̊K�w�ɑ}��
                        NewFloor.transform.SetSiblingIndex(floor.transform.GetSiblingIndex());
                    }
                    //������object��j��
                    DestroyImmediate(floor.gameObject);
                }
            }
            //�擾�ł��Ă��Ȃ��ꍇ��ERROR
            else
            {
                EditorGUILayout.HelpBox("No prefab assigned for the selected role.", MessageType.Warning);
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            ChangeShape();
            floor.MoveBlockPrefab = EditorGUILayout.ObjectField("Move Block Prefab", floor.MoveBlockPrefab, typeof(GameObject), false) as GameObject;
            if (GUILayout.Button("なんかすごいボタン"))
            {
                // 現在の位置を取得
                Vector3 currentPosition = floor.transform.position;

                // Y+1の位置にPrefabを生成
                GameObject newPrefab = PrefabUtility.InstantiatePrefab(floor.MoveBlockPrefab) as GameObject;
                newPrefab.transform.position = currentPosition + Vector3.up;

                newPrefab.transform.parent = floor.transform;
            }

            if (target == null) return;
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}