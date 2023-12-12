using System.Collections;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject[] Walls;
    public testmove TestMove;
    public CameraRotation Rotation;

    void Update()
    {
        for (int i = 0; i < Walls.Length; i++)
        {
            if (TestMove.Up == i)
            {
                Walls[i].SetActive(false);
            }
            else
            {
                StartCoroutine(ShowWallAfterRotation(i));
            }
        }
    }

    IEnumerator ShowWallAfterRotation(int wallIndex)
    {
        // �J������]���̑ҋ@
        while (Rotation.count != 0)
        {
            Debug.Log("�ҋ@��");
            yield return null;
        }

        // �J������]���I�������ǂ�\��
        if (Rotation.count == 0)
            Walls[wallIndex].gameObject.SetActive(true);
        //Debug.Log("��]����");
    }
          
}