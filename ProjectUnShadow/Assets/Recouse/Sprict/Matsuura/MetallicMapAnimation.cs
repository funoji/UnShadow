using UnityEngine;
using System.Collections;

public class MetallicMapAnimation : MonoBehaviour
{
    public Material targetMaterial;
    public float animationSpeed = 1f;
    public float scaleSpeed = 1f; // アニメーションの速度
    private bool increasing = true;

    private void Start()
    {
        StartCoroutine(ScaleAnimation());
    }

    private void Update()
    {
        // マテリアルが指定されているか確認
        if (targetMaterial == null)
        {
            Debug.LogError("Target material is not assigned.");
            return;
        }

        // Metallic Mapの値を変更
        float metallicValue = targetMaterial.GetFloat("_Metallic");

        // 増加または減少の判定
        if (increasing)
        {
            metallicValue += Time.deltaTime * animationSpeed;
            if (metallicValue >= 1f)
            {
                metallicValue = 1f;
                increasing = false;
            }
        }
        else
        {
            metallicValue -= Time.deltaTime * animationSpeed;
            if (metallicValue <= 0.3f)
            {
                metallicValue = 0.3f;
                increasing = true;
            }
        }

        targetMaterial.SetFloat("_Metallic", metallicValue);
    }
    IEnumerator ScaleAnimation()
    {
        while (true)
        {
            // スケールを計算
            float scaleFactor = Mathf.Lerp(1f, 0.1f, Mathf.PingPong(Time.time * scaleSpeed, 1f));

            // XとZのスケールを設定
            transform.localScale = new Vector3(scaleFactor, transform.localScale.y, scaleFactor);
            yield return null;
        }
    }
}