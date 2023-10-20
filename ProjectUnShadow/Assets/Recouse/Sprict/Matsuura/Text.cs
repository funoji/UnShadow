using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHP;
    public testmove helth;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(helth.PlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.text = "HP:" + helth.PlayerHP.ToString();    
    }
}
