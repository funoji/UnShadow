using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Floor : MonoBehaviour
{
    [SerializeField] FloorPrefabs floorPrefabs;
    
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
        Shadow,
    }
    [SerializeField] private FloorRoles Roles = FloorRoles.NULL;

    public enum MoveStatus
    { CanStep,CantStep }
    [SerializeField] private MoveStatus moveStatus;

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

#if UNITY_EDITOR
    [CustomEditor(typeof(Floor))]
    class ChangeFloors : Editor
    {
        FloorRoles currentRole;
        Floor floor;
        [SerializeField] GameObject CreateObj;
        private Dictionary<FloorRoles, GameObject> prefabDictionary = new Dictionary<FloorRoles, GameObject>();

        private void OnEnable()
        {
            floor = (Floor)target;
            floor.floorPrefabs = GameObject.Find("CreateStage").GetComponent<FloorPrefabs>();
            CreateObj = GameObject.Find("CreateStage");

            // プレハブをディクショナリに追加
            //新しいオブジェクトを追加する場合 prefabDictionary.Add(FloorRoles.〇〇, floor.floorPrefabs.〇〇);としてください。
            prefabDictionary.Clear();
            prefabDictionary.Add(FloorRoles.Normal, floor.floorPrefabs.NormalFloorObj);
            prefabDictionary.Add(FloorRoles.Start, floor.floorPrefabs.StartFloorObj);
            prefabDictionary.Add(FloorRoles.Goal, floor.floorPrefabs.GoalFloorObj);
            prefabDictionary.Add(FloorRoles.FirstHeight, floor.floorPrefabs.FirstHeight);
            prefabDictionary.Add(FloorRoles.SecondHeight, floor.floorPrefabs.SecondHeight);
            prefabDictionary.Add(FloorRoles.ThirdHeight, floor.floorPrefabs.ThirdHeight);
            prefabDictionary.Add(FloorRoles.SolarPanel, floor.floorPrefabs.SolarPanel);
            prefabDictionary.Add(FloorRoles.EnemySponer, floor.floorPrefabs.EnemySponar);
            prefabDictionary.Add(FloorRoles.Shadow, floor.floorPrefabs.ShadowCreat);
        }

        void ChangeShape()
        {
            EditorGUI.BeginChangeCheck();
            UnityEditor.SerializedProperty RoleProperty = serializedObject.FindProperty("Roles");
            EditorGUILayout.PropertyField(RoleProperty);
            currentRole = (FloorRoles)RoleProperty.enumValueIndex;
            GameObject NewFloor;
            //Roleでprefabが取得できているか確認
            if (prefabDictionary.TryGetValue(currentRole, out GameObject create))
            {
                //取得できていた場合
                if (EditorGUI.EndChangeCheck())
                {
                    //インスタンス化
                    NewFloor = GameObject.Instantiate(create, floor.transform.position, Quaternion.identity);
                    if (CreateObj)
                    {
                        //子オブジェクトに格納
                        NewFloor.transform.parent = CreateObj.transform;
                        //指定の階層に挿入
                        NewFloor.transform.SetSiblingIndex(floor.transform.GetSiblingIndex());
                    }
                    //元あるobjectを破壊
                    DestroyImmediate(floor.gameObject);
                }
            }
            //取得できていない場合はERROR
            else
            {
                EditorGUILayout.HelpBox("No prefab assigned for the selected role.", MessageType.Warning);
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            ChangeShape();
            if (target == null) return;
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}