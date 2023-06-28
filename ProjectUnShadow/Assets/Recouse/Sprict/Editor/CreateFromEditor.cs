using UnityEngine;
using UnityEditor;
using System.Collections;

public class CreateFromEdtor : EditorWindow
{
    private GameObject FristInstancePos;
    private GameObject FloorPrefab;
    private int LengthHori = 0;
    private int LengthVer = 0;
    private int Half = 2;
    GameObject[] Floors;

    [MenuItem("Window/CreateStageFloor")]
    static void Init()
    {
        EditorWindow.GetWindow<CreateFromEdtor>(true, "CreateStageFloor");
    }

    void OnEnable()
    {
        if (Selection.gameObjects.Length > 0) FristInstancePos = Selection.gameObjects[0];
        FristInstancePos = GameObject.Find("CreateStage");
    }

    //UI内の表示とデータの取得
    void OnGUI()
    {
        try
        {
            FristInstancePos = EditorGUILayout.ObjectField("正方形の中心のプレハブ", FristInstancePos, typeof(GameObject), true) as GameObject;
            FloorPrefab = EditorGUILayout.ObjectField("床のプレハブ", FloorPrefab, typeof(GameObject), true) as GameObject;

            GUILayout.Label("X : ", EditorStyles.boldLabel);
            LengthHori = int.Parse(EditorGUILayout.TextField("縦の長さ", LengthHori.ToString()));

            GUILayout.Label("Y : ", EditorStyles.boldLabel);
            LengthVer = int.Parse(EditorGUILayout.TextField("横の長さ", LengthVer.ToString()));

            GUILayout.Label("", EditorStyles.boldLabel);
            if (GUILayout.Button("Create")) Create();
        }
        catch (System.FormatException) { }
    }

    //実際にオブジェクトを作成
    private void Create()
    {
        

        //インスタンス化するobjectがない場合の処理
        if (FloorPrefab == null) { Debug.Log("床のプレハブを設定してください"); return; }

        //インスタンスの開始地点を指定
        Vector3 InstancePos = FristInstancePos.transform.position;

        //インスタンス化するobjectの中心がFristInstancePosに補正
        InstancePos.x -= LengthHori / Half;
        InstancePos.z -= LengthVer / Half;
        Vector3 _InstancePos = InstancePos;

        //正方形か長方形になるようにFloorをインスタンス化
        for (int i = 0; i<LengthHori; i++)
        {
           for(int ii = 0; ii < LengthVer; ii++)
            {
                GameObject InstedFloor = GameObject.Instantiate(FloorPrefab,_InstancePos,Quaternion.identity);//インスタンス化
                if (FristInstancePos) InstedFloor.transform.parent = FristInstancePos.transform;//子オブジェクトに格納
                Undo.RegisterCreatedObjectUndo(InstedFloor, "CreateStageFloor");//unity上での巻き戻しを実現
                _InstancePos.x++;//positionの補正

            }
            _InstancePos.z++;//positionの補正
            _InstancePos.x = InstancePos.x;//positionの補正
        }
    }
}
