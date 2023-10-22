using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotarusScript : MonoBehaviour
{
    LightContlloer lightContlloer;
    [SerializeField] GameObject[] Hotarus;
    testmove TestMove;
    // Start is called before the first frame update
    void Start()
    {
        if (lightContlloer == null)
            lightContlloer = GameObject.Find("light").GetComponent<LightContlloer>();
        if (TestMove == null)
            TestMove = GameObject.Find("player_rig3").GetComponent<testmove>();
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
            {
                Hotarus[i].gameObject.SetActive(false);
            }
            if (TestMove.Down == i)
            {
                Hotarus[i].gameObject.SetActive(false);
            }
        }
    }
}