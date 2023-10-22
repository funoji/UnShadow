using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotarusScript : MonoBehaviour
{
    LightContlloer lightContlloer;
    [SerializeField] GameObject []Hotarus;
    // Start is called before the first frame update
    void Start()
    {
        // LightContlloer �N���X�̃C���X�^���X���擾���邩�A�V�����쐬����
        lightContlloer = GetComponent<LightContlloer>();
        if (lightContlloer == null)
        {
            lightContlloer = GameObject.Find("light").GetComponent<LightContlloer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lightContlloer.lights.Length; i++)
        {
            if (lightContlloer.lights[i].enabled)
            {
                Hotarus[i].gameObject.SetActive(true);
            }
            else
                Hotarus[i].gameObject.SetActive(false);
        }
    }
}