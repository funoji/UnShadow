using UnityEngine;

public class TrailEffectSpawner : MonoBehaviour
{
    public GameObject trailEffectPrefab; // トレイルエフェクトのプレハブ

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // スペースキーが押されたときにトレイルエフェクトをインスタンス化する
            InstantiateTrailEffect();
        }
    }

    private void InstantiateTrailEffect()
    {
        if (trailEffectPrefab != null)
        {
            // トレイルエフェクトのインスタンスを生成
            GameObject trailEffectInstance = Instantiate(trailEffectPrefab, transform.position, Quaternion.identity);

            // 生成したエフェクトを一定時間後に停止させる
            TrailRenderer[] trailRenderers = trailEffectInstance.GetComponentsInChildren<TrailRenderer>();
            foreach (TrailRenderer trailRenderer in trailRenderers)
            {
                trailRenderer.emitting = true; // トレイルを再生
                trailRenderer.gameObject.SetActive(true); // GameObjectをアクティブにする
                StartCoroutine(StopTrailAfterDelay(trailRenderer, 2.0f)); // 2秒後に再生を停止
            }
        }
    }

    private System.Collections.IEnumerator StopTrailAfterDelay(TrailRenderer trailRenderer, float delay)
    {
        yield return new WaitForSeconds(delay);
        trailRenderer.emitting = false; // トレイルの再生を停止
        trailRenderer.gameObject.SetActive(false); // GameObjectを非アクティブにする
    }
}