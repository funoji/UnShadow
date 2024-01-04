using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGimmick : MonoBehaviour
{
    private List<GameObject> taggedObjects = new List<GameObject>();
    SolarPanel scriptOnSoraObject;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        // 衝突相手のオブジェクトが "sora" タグを持つ場合
        if (other.CompareTag("sora"))
        {
            // ここに当たり判定が発生した際の処理を記述します
            Debug.Log("sora タグのオブジェクトと当たりました");
            scriptOnSoraObject = other.GetComponent<SolarPanel>();
            // スクリプトが取得できたか確認
            if (scriptOnSoraObject != null)
            {
                // スクリプトの関数を呼び出す
                scriptOnSoraObject.OffBarrier();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("sora"))
        {
            scriptOnSoraObject.OnBarrier();
        }
    }
    private void OnDestroy()
    {
        // このスクリプトをアタッチしているオブジェクトが削除された際の処理
        Debug.Log("このオブジェクトが削除されました");

        // scriptOnSoraObjectがnullでない場合、OnBarrierを呼び出す
        if (scriptOnSoraObject != null)
        {
            scriptOnSoraObject.OnBarrier();
        }
    }
}
