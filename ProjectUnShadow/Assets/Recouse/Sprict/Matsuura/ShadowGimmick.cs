using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowGimmick : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // 衝突相手のオブジェクトが "sora" タグを持つ場合
        if (other.CompareTag("sora"))
        {
            // ここに当たり判定が発生した際の処理を記述します
            Debug.Log("sora タグのオブジェクトと当たりました");
        }
    }
}
