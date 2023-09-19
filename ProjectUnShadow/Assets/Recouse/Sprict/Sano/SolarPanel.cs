using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SolarPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] Bariiers;
    Barrier Barrier;

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
        Barrier.setOn();
    }
    public void OffBarrier()
    {
 �@�@�@ //if is this shadow
        Barrier.setOff();
    }
}