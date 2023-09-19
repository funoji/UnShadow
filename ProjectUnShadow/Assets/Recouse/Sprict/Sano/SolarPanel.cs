using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SolarPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] Bariiers;

    private void Start()
    {
        // Bariiers �z����̊e�I�u�W�F�N�g�ɑ΂��� MoveStatus ��ݒ�
        foreach (var barrier in Bariiers)
        {
            Floor floor = barrier.GetComponent<Floor>();
            if (floor != null)
            {
                floor.SetMoveStatus((Floor.MoveStatus)1); // �܂��� CantStep �ɐݒ�
            }
        }
    }
    public void OnBarrier()
    {
        //if is this Unshadow
        for(int i = 0;i < Bariiers.Length;i++)
        {
           Bariiers[i].GetComponent<Barrier>().setOn();
        }
    }
    public void OffBarrier()
    {
        //if is this shadow
        for (int i = 0; i < Bariiers.Length; i++)
        {
            Bariiers[i].GetComponent<Barrier>().setOff();
        }
    }
}