using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class LightcountText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lightcount;
    public LightContlloer LightContlloer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightcount.text = "Light:" + LightContlloer.lightcount.ToString();
    }
}
