using UnityEngine;

public class MetallicMapAnimation : MonoBehaviour
{
    public Material targetMaterial;
    public float animationSpeed = 1f;

    private bool increasing = true;

    private void Update()
    {
        // �}�e���A�����w�肳��Ă��邩�m�F
        if (targetMaterial == null)
        {
            Debug.LogError("Target material is not assigned.");
            return;
        }

        // Metallic Map�̒l��ύX
        float metallicValue = targetMaterial.GetFloat("_Metallic");

        // �����܂��͌����̔���
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