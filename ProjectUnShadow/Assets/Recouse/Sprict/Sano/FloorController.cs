using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorController : MonoBehaviour
{
    [SerializeField] int Hori;
    [SerializeField] int ver;
    Floor floor;

    // Start is called before the first frame update
    void Start()
    {
        Floor.FloorRoles[][] floorComponent = new Floor.FloorRoles[Hori][];
        for (int i = 0; i < Hori; i++)
        {
            floorComponent[i] = new Floor.FloorRoles[ver];
        }

        for (int i = 0; i < Hori; i++)
        {
            for (int ii = 0; ii < ver; ii++)
            {
                floorComponent[i][ii] = this.transform.GetChild(ii).GetComponent<Floor>().GetRoles();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}