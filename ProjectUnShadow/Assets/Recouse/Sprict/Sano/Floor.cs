using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Floor : MonoBehaviour
{
    [SerializeField] FloorPrefabs floorPrefabs;
    
    enum FloorRoles
    {
        Normal,
        Start,
        Goal,
        FirstHeight,
        SecondHeight,
        ThirdHeight,
        SolarPanel,
        EnemySponer,
        ShadowCreat
    }
    [SerializeField] FloorRoles Roles;

    private void Reset()
    {
        floorPrefabs = GameObject.Find("CreateStage").GetComponent<FloorPrefabs>();
    }



#if UNITY_EDITOR
    [CustomEditor(typeof(Floor))]
    class ChangeFloors : Editor
    {
        FloorRoles currentRole;
        Floor floor;
        [SerializeField] GameObject CreateObj;

        private void OnEnable()
        {
            floor = (Floor)target;
            floor.floorPrefabs = GameObject.Find("CreateStage").GetComponent<FloorPrefabs>();
            CreateObj = GameObject.Find("CreateStage");
        }

        void ChangeShape()
        {
            EditorGUI.BeginChangeCheck();
            UnityEditor.SerializedProperty RoleProperty = serializedObject.FindProperty("Roles");
            EditorGUILayout.PropertyField(RoleProperty);
            currentRole = (FloorRoles) RoleProperty.enumValueIndex;
            GameObject NewFloor;

            if (EditorGUI.EndChangeCheck())
            {
                switch (currentRole)
                {
                    case FloorRoles.Normal:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.NormalFloorObj, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.Start:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.StartFloorObj, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        //Undo.RegisterCreatedObjectUndo(floor.floorPrefabs.StartObj, "Roles");//unity上での巻き戻しを実現
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.Goal:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.GoalFloorObj, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.FirstHeight:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.FirstHeight, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.SecondHeight:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.SecondHeight, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.ThirdHeight:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.ThirdHeight, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.SolarPanel:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.SolarPanel, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.EnemySponer:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.EnemySponar, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                    case FloorRoles.ShadowCreat:
                        NewFloor = GameObject.Instantiate(floor.floorPrefabs.ShadowCreat, floor.gameObject.transform.position, Quaternion.identity);
                        if (CreateObj) NewFloor.transform.parent = CreateObj.transform;//子オブジェクトに格納
                        DestroyImmediate(floor.gameObject);
                        break;
                }
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