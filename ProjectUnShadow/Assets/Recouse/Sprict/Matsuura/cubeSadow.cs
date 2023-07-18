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
    [SerializeField] GameObject effectPrefab;
    // エフェクトインスタンスの変数を方向ごとに宣言
    private GameObject effectInstanceUp;
    private GameObject effectInstanceDown;
    private GameObject effectInstanceLeft;
    private GameObject effectInstanceRight;
    private Quaternion effectRotation;
    // Start is called before the first frame update
    private void Start()
    {
        // オブジェクトの位置を取得
        objectPosition = transform.position;
        up = objectPosition + new Vector3(0, 0, -1);
        down = objectPosition + new Vector3(0, 0, 1);
        right = objectPosition + new Vector3(-1, 0, 0);
        left = objectPosition + new Vector3(1, 0, 0);
        effectRotation = effectPrefab.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //上のライトがついたとき
        if (Light.lights[0].enabled == true)
        {
            if (currentBlockup == null)
            {
                currentBlockup = Instantiate(ShadowBox, up, Quaternion.identity);
                effectInstanceUp = Instantiate(effectPrefab, up, effectRotation);
            }
        }
        if (Light.lights[0].enabled == false)
        {
            Destroy(currentBlockup);
            Destroy(effectInstanceUp);
            currentBlockup = null;
        }

        //下のライトがついたとき
        if (Light.lights[1].enabled == true)
        {
            if (currentBlockdown == null)
            {
                currentBlockdown = Instantiate(ShadowBox, down, Quaternion.identity);
                effectInstanceDown = Instantiate(effectPrefab, down, effectRotation);
            }
        }
        if (Light.lights[1].enabled == false)
        {
            Destroy(currentBlockdown);
            Destroy(effectInstanceDown);
            currentBlockdown = null;
        }

        //右のライトがついたとき
        if (Light.lights[2].enabled == true)
        {
            if (currentBlockright == null)
            {
                currentBlockright = Instantiate(ShadowBox, right, Quaternion.identity);
                effectInstanceRight = Instantiate(effectPrefab, right, effectRotation);
            }
                
        }
        if (Light.lights[2].enabled == false)
        {
            Destroy(currentBlockright);
            Destroy(effectInstanceRight);
            currentBlockright = null;
        }

        //左のライトがついたとき
        if (Light.lights[3].enabled == true)
        {
            if (currentBlockleft == null)
            {
                currentBlockleft = Instantiate(ShadowBox, left, Quaternion.identity);
                effectInstanceLeft = Instantiate(effectPrefab, left, effectRotation);
            }
                
        }
        if (Light.lights[3].enabled == false)
        {
            Destroy(currentBlockleft);
            Destroy(effectInstanceLeft);
            currentBlockleft = null;
        }
    }
}
