using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightContlloer : MonoBehaviour
{
    public Light[] lights; // 切り替えるライトの配列

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ToggleLight(0); // ライトのインデックスを指定して切り替える
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ToggleLight(1); // ライトのインデックスを指定して切り替える
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleLight(2); // ライトのインデックスを指定して切り替える
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleLight(3); // ライトのインデックスを指定して切り替える
        }
    }

    public void ToggleLight(int index)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (i == index)
            {
                lights[i].enabled = true; // 指定したライトを有効にする
            }
            else
            {
                lights[i].enabled = false; // 他のライトを無効にする
            }
        }
    }
}
