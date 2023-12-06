using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float animationSpeed = 0.5f; // アニメーションの速さ
    public float minIntensity = 0.2f; // 最小の明るさ
    public float maxIntensity = 1.0f; // 最大の明るさ

    private bool increasing = true; // 増加中かどうかのフラグ

    public void ToggleLightIntensity(Light targetLight)
    {
        StartCoroutine(ChangeLightIntensity(targetLight));
    }

    IEnumerator ChangeLightIntensity(Light targetLight)
    {
        while (true)
        {
            // 明るさの値を変更
            float intensityValue = targetLight.intensity;

            // 増加または減少の判定
            if (increasing)
            {
                intensityValue += Time.deltaTime * animationSpeed;
                if (intensityValue >= maxIntensity)
                {
                    intensityValue = maxIntensity;
                    increasing = false;
                }
            }
            else
            {
                intensityValue -= Time.deltaTime * animationSpeed;
                if (intensityValue <= minIntensity)
                {
                    intensityValue = minIntensity;
                    increasing = true;
                }
            }

            targetLight.intensity = intensityValue;
            yield return null;
        }
    }
}
