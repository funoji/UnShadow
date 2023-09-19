using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SolarPanel : Floor
{
    [SerializeField] private GameObject[] Bariiers;
    private void Start()
    {
        for(int Bi = 0; Bi < Bariiers.Length; Bi++)
        {
            Bariiers[Bi].GetComponent<Floor>().SetMoveStatus((MoveStatus)1);
        }
    }
}