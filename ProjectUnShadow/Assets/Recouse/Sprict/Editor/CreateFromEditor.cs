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

    //UI���̕\���ƃf�[�^�̎擾
    void OnGUI()
    {
        try
        {
            FristInstancePos = EditorGUILayout.ObjectField("�����`�̒��S�̃v���n�u", FristInstancePos, typeof(GameObject), true) as GameObject;
            FloorPrefab = EditorGUILayout.ObjectField("���̃v���n�u", FloorPrefab, typeof(GameObject), true) as GameObject;

            GUILayout.Label("X : ", EditorStyles.boldLabel);
            LengthHori = int.Parse(EditorGUILayout.TextField("�c�̒���", LengthHori.ToString()));

            GUILayout.Label("Y : ", EditorStyles.boldLabel);
            LengthVer = int.Parse(EditorGUILayout.TextField("���̒���", LengthVer.ToString()));

            GUILayout.Label("", EditorStyles.boldLabel);
            if (GUILayout.Button("Create")) Create();
        }
        catch (System.FormatException) { }
    }

    //���ۂɃI�u�W�F�N�g���쐬
    private void Create()
    {
        

        //�C���X�^���X������object���Ȃ��ꍇ�̏���
        if (FloorPrefab == null) { Debug.Log("���̃v���n�u��ݒ肵�Ă�������"); return; }

        //�C���X�^���X�̊J�n�n�_���w��
        Vector3 InstancePos = FristInstancePos.transform.position;

        //�C���X�^���X������object�̒��S��FristInstancePos�ɕ␳
        InstancePos.x -= LengthHori / Half;
        InstancePos.z -= LengthVer / Half;
        Vector3 _InstancePos = InstancePos;

        //�����`�������`�ɂȂ�悤��Floor���C���X�^���X��
        for (int i = 0; i<LengthHori; i++)
        {
           for(int ii = 0; ii < LengthVer; ii++)
            {
                GameObject InstedFloor = GameObject.Instantiate(FloorPrefab,_InstancePos,Quaternion.identity);//�C���X�^���X��
                if (FristInstancePos) InstedFloor.transform.parent = FristInstancePos.transform;//�q�I�u�W�F�N�g�Ɋi�[
                Undo.RegisterCreatedObjectUndo(InstedFloor, "CreateStageFloor");//unity��ł̊����߂�������
                _InstancePos.x++;//position�̕␳

            }
            _InstancePos.z++;//position�̕␳
            _InstancePos.x = InstancePos.x;//position�̕␳
        }
    }
}
