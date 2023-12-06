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
        // カメラ回転中の待機
        while (Rotation.R && Rotation.L)
        {
            yield return null;
        }

        // カメラ回転が終わったら壁を表示
        if (Rotation.count == 0)
            Walls[wallIndex].gameObject.SetActive(true);
    }
}