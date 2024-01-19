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
    private float moveSpeed = 1.0f;
    // Start is called before the first frame update
    private void Start()
    {
        Light= GameObject.Find("light").GetComponent<LightContlloer>();
        // オブジェクトの位置を取得
        objectPosition = transform.position; 
        effectRotation = effectPrefab.transform.rotation;
        up = new Vector3(0, 0, -1);
        down = new Vector3(0, 0, 1);
        right = new Vector3(-1, 0, 0);
        left = new Vector3(1, 0, 0);
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
                    LightInstantiate(currentBlockupList, effectInstanceUpList, up, new Vector3(0, 0, -i));
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
                    LightInstantiate(currentBlockrightList, effectInstanceRightList, right, new Vector3(-i, 0, 0));
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
                    LightInstantiate(currentBlockdownList, effectInstanceDownList, down, new Vector3(0, 0, i));
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
                    LightInstantiate(currentBlockleftList,effectInstanceLeftList,left, new Vector3(i, 0, 0));
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
    void LightInstantiate(List<GameObject> Block, List<GameObject> effect, Vector3 direction, Vector3 move)
    {
        objectPosition = transform.position;
        effectRotation = effectPrefab.transform.rotation;
        GameObject currentBlock = Instantiate(ShadowBox, objectPosition + direction + move, Quaternion.identity);
        GameObject effectInstance = Instantiate(effectPrefab, objectPosition + direction + move, effectRotation);
        Block.Add(currentBlock);
        effect.Add(effectInstance);
    }
public void MoveShadow(Vector3 move)
    {
        // 各方向の影を移動
        StartCoroutine(MoveShadowList(currentBlockupList, move, Vector3.back));
        StartCoroutine(MoveShadowList(currentBlockdownList, move, Vector3.forward));
        StartCoroutine(MoveShadowList(currentBlockleftList, move, Vector3.left));
        StartCoroutine(MoveShadowList(currentBlockrightList, move, Vector3.right));

        // エフェクトも同様に移動
        StartCoroutine(MoveShadowList(effectInstanceUpList, move, Vector3.back));
        StartCoroutine(MoveShadowList(effectInstanceDownList, move, Vector3.forward));
        StartCoroutine(MoveShadowList(effectInstanceLeftList, move, Vector3.left));
        StartCoroutine(MoveShadowList(effectInstanceRightList, move, Vector3.right));
    }
    private IEnumerator MoveShadowList(List<GameObject> shadowList, Vector3 move, Vector3 direction)
    {

        for (int i = 0; i < shadowList.Count; i++)
        {
            Vector3 targetPosition = shadowList[i].transform.position + move;
            while (shadowList[i].transform.position != targetPosition)
            {
                shadowList[i].transform.position = Vector3.MoveTowards(shadowList[i].transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        yield return null;
    }
}
