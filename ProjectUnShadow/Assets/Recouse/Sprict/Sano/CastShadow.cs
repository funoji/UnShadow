using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastShadow : MonoBehaviour
{
    [SerializeField] GameObject[] lightObj;
    Floor.FloorRoles CheckRole;
    // Start is called before the first frame update
    void Start()
    {
        CheckRole = this.GetComponent<Floor.FloorRoles>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
