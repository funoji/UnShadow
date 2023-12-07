using UnityEngine;
using System.Collections;

public class MetallicMapAnimation : MonoBehaviour
{
    public Material targetMaterial;
    public float animationSpeed = 1f;
    public float scaleSpeed = 1f; // �A�j���[�V�����̑��x
    private bool increasing = true;

    private void Start()
    {
        StartCoroutine(ScaleAnimation());
    }

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
    IEnumerator ScaleAnimation()
    {
        while (true)
        {
            // �X�P�[�����v�Z
            float scaleFactor = Mathf.Lerp(1f, 0.1f, Mathf.PingPong(Time.time * scaleSpeed, 1f));

            // X��Z�̃X�P�[����ݒ�
            transform.localScale = new Vector3(scaleFactor, transform.localScale.y, scaleFactor);
            yield return null;
        }
    }
}