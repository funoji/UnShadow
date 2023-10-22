using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotarusScript : MonoBehaviour
{
    LightContlloer lightContlloer;
    [SerializeField] GameObject Hotarus;
    // Start is called before the first frame update
    void Start()
    {
        // LightContlloer クラスのインスタンスを取得するか、新しく作成する
        lightContlloer = GetComponent<LightContlloer>();
        if (lightContlloer == null)
        {
            lightContlloer = GameObject.Find("light").GetComponent<LightContlloer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // lightContlloer が null でないことを確認する
        if (lightContlloer != null && lightContlloer.lights != null && lightContlloer.lights.Length > 1 && lightContlloer.lights[1] != null && lightContlloer.lights[1].enabled)
        {
            // lightContlloer が null でなく、lights 配列が null でなく、長さが2以上あり、lights[1] が null でなく、enabled が true の場合
            Hotarus.gameObject.SetActive(true);
        }
        else
        {
            Hotarus.gameObject.SetActive(false);
        }
    }
}