using UnityEngine;

public class MetallicMapAnimation : MonoBehaviour
{
    public Material targetMaterial;
    public float animationSpeed = 1f;

    private bool increasing = true;

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
}