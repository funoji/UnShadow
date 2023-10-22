using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotarusScript : MonoBehaviour
{
    LightContlloer lightContlloer;
    [SerializeField] GameObject Hotarus;
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
        // lightContlloer �� null �łȂ����Ƃ��m�F����
        if (lightContlloer != null && lightContlloer.lights != null && lightContlloer.lights.Length > 1 && lightContlloer.lights[1] != null && lightContlloer.lights[1].enabled)
        {
            // lightContlloer �� null �łȂ��Alights �z�� null �łȂ��A������2�ȏ゠��Alights[1] �� null �łȂ��Aenabled �� true �̏ꍇ
            Hotarus.gameObject.SetActive(true);
        }
        else
        {
            Hotarus.gameObject.SetActive(false);
        }
    }
}