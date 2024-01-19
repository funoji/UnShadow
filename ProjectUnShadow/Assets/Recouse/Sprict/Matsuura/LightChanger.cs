using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    public float animationSpeed = 0.5f; // �A�j���[�V�����̑���
    public float minIntensity = 0.2f; // �ŏ��̖��邳
    public float maxIntensity = 1.0f; // �ő�̖��邳

    private bool increasing = true; // ���������ǂ����̃t���O

    public void ToggleLightIntensity(Light targetLight)
    {
        StartCoroutine(ChangeLightIntensity(targetLight));
    }

    IEnumerator ChangeLightIntensity(Light targetLight)
    {
        while (true)
        {
            // ���邳�̒l��ύX
            float intensityValue = targetLight.intensity;

            // �����܂��͌����̔���
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
