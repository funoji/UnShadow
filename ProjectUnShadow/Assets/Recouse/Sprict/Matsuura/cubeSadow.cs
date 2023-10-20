using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeSadow : MonoBehaviour
{
    GameObject LightObj;
    private LightContlloer Light;
    Vector3 objectPosition;
    Vector3 up, down, left, right;
    public GameObject ShadowBox;
    private List<GameObject> currentBlockupList = new List<GameObject>();
    private List<GameObject> currentBlockdownList = new List<GameObject>();
    private List<GameObject> currentBlockleftList = new List<GameObject>();
    private List<GameObject> currentBlockrightList = new List<GameObject>();
    [SerializeField] GameObject effectPrefab;
    // エフェクトインスタンスの変数を方向ごとに宣言
    private List<GameObject> effectInstanceUpList = new List<GameObject>();
    private List<GameObject> effectInstanceDownList = new List<GameObject>();
    private List<GameObject> effectInstanceLeftList = new List<GameObject>();
    private List<GameObject> effectInstanceRightList = new List<GameObject>();
    private Quaternion effectRotation;

    [SerializeField] int s;
    // Start is called before the first frame update
    private void Start()
    {
        Light= GameObject.Find("light").GetComponent<LightContlloer>();
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
            if (currentBlockupList.Count == 0)
            {
                for (int i = 0; i < s; i++)
                {
                    GameObject currentBlockup = Instantiate(ShadowBox, up + new Vector3(0, 0, -i), Quaternion.identity);
                    GameObject effectInstanceUp = Instantiate(effectPrefab, up + new Vector3(0, 0, -i), effectRotation);
                    currentBlockupList.Add(currentBlockup);
                    effectInstanceUpList.Add(effectInstanceUp);
                }
            }
        }
        if (Light.lights[0].enabled == false)
        {
            foreach (var block in currentBlockupList)
            {
                Destroy(block);
            }
            foreach (var effect in effectInstanceUpList)
            {
                Destroy(effect);
            }
            currentBlockupList.Clear();
            effectInstanceUpList.Clear();
        }
        //右のライトがついたとき
        if (Light.lights[1].enabled == true)
        {
            if (currentBlockrightList.Count == 0)
            {
                for (int i = 0; i < s; i++)
                {
                    GameObject currentBlockright = Instantiate(ShadowBox, right + new Vector3(-i, 0, 0), Quaternion.identity);
                    GameObject effectInstanceRight = Instantiate(effectPrefab, right + new Vector3(-i, 0, 0), effectRotation);
                    currentBlockrightList.Add(currentBlockright);
                    effectInstanceRightList.Add(effectInstanceRight);
                }
            }

        }
        if (Light.lights[1].enabled == false)
        {
            foreach (var block in currentBlockrightList)
            {
                Destroy(block);
            }
            foreach (var effect in effectInstanceRightList)
            {
                Destroy(effect);
            }
            currentBlockrightList.Clear();
            effectInstanceRightList.Clear();
        }

        //下のライトがついたとき
        if (Light.lights[2].enabled == true)
        {
            if (currentBlockdownList.Count == 0)
            {
                for (int i = 0; i < s; i++)
                {
                    GameObject currentBlockdown = Instantiate(ShadowBox, down + new Vector3(0, 0, i), Quaternion.identity);
                    GameObject effectInstanceDown = Instantiate(effectPrefab, down + new Vector3(0, 0, i), effectRotation);
                    currentBlockdownList.Add(currentBlockdown);
                    effectInstanceDownList.Add(effectInstanceDown);
                }
            }
        }
        if (Light.lights[2].enabled == false)
        {
            foreach (var block in currentBlockdownList)
            {
                Destroy(block);
            }
            foreach (var effect in effectInstanceDownList)
            {
                Destroy(effect);
            }
            currentBlockdownList.Clear();
            effectInstanceDownList.Clear();
        }

        //左のライトがついたとき
        if (Light.lights[3].enabled == true)
        {
            if (currentBlockleftList.Count == 0)
            {
                for (int i = 0; i < s; i++)
                {
                    GameObject currentBlockleft = Instantiate(ShadowBox, left + new Vector3(i, 0, 0), Quaternion.identity);
                    GameObject effectInstanceLeft = Instantiate(effectPrefab, left + new Vector3(i, 0, 0), effectRotation);
                    currentBlockleftList.Add(currentBlockleft);
                    effectInstanceLeftList.Add(effectInstanceLeft);
                }
            }

        }
        if (Light.lights[3].enabled == false)
        {
            foreach (var block in currentBlockleftList)
            {
                Destroy(block);
            }
            foreach (var effect in effectInstanceLeftList)
            {
                Destroy(effect);
            }
            currentBlockleftList.Clear();
            effectInstanceLeftList.Clear();
        }
    }
}
