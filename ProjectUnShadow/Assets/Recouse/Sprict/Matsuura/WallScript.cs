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
        // ƒJƒƒ‰‰ñ“]’†‚Ì‘Ò‹@
        while (Rotation.count != 0)
        {
            Debug.Log("‘Ò‹@’†");
            yield return null;
        }

        // ƒJƒƒ‰‰ñ“]‚ªI‚í‚Á‚½‚ç•Ç‚ð•\Ž¦
        if (Rotation.count == 0)
            Walls[wallIndex].gameObject.SetActive(true);
        //Debug.Log("‰ñ“]Š®—¹");
    }
          
}