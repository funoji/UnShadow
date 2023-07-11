using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSadow : MonoBehaviour
{
    GameObject LightObj;
    public LightContlloer Light;
    Vector3 objectPosition;
    Vector3 up, down, left, right;
    public GameObject ShadowBox;
    private GameObject currentBlockup;
    private GameObject currentBlockdown;
    private GameObject currentBlockleft;
    private GameObject currentBlockright;
    // Start is called before the first frame update
    private void Start()
    {
        // オブジェクトの位置を取得
        objectPosition = transform.position;
        up = objectPosition + new Vector3(0, 0, -1);
        down = objectPosition + new Vector3(0, 0, 1);
        right = objectPosition + new Vector3(-1, 0, 0);
        left = objectPosition + new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //上のライトがついたとき
        if (Light.lights[0].enabled == true)
        {
            if (currentBlockup == null)
                currentBlockup = Instantiate(ShadowBox, up, Quaternion.identity);
        }
        if (Light.lights[0].enabled == false)
        {
            Destroy(currentBlockup);
            currentBlockup = null;
        }

        //下のライトがついたとき
        if (Light.lights[1].enabled == true)
        {
            if (currentBlockdown == null)
                currentBlockdown = Instantiate(ShadowBox, down, Quaternion.identity);
        }
        if (Light.lights[1].enabled == false)
        {
            Destroy(currentBlockdown);
            currentBlockdown = null;
        }

        //右のライトがついたとき
        if (Light.lights[2].enabled == true)
        {
            if (currentBlockright == null)
                currentBlockright = Instantiate(ShadowBox, right, Quaternion.identity);
        }
        if (Light.lights[2].enabled == false)
        {
            Destroy(currentBlockright);
            currentBlockright = null;
        }

        //左のライトがついたとき
        if (Light.lights[3].enabled == true)
        {
            if (currentBlockleft == null)
                currentBlockleft = Instantiate(ShadowBox, left, Quaternion.identity);
        }
        if (Light.lights[3].enabled == false)
        {
            Destroy(currentBlockleft);
            currentBlockleft = null;
        }
    }
}
