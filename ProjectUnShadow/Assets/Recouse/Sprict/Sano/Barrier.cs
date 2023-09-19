using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] GameObject BarObj;

    public void setOn()
    {
        this.GetComponent<Floor>().SetMoveStatus((Floor.MoveStatus)1);
        BarObj.SetActive(true);
    }
    public void setOff()
    {
        this.GetComponent<Floor>().SetMoveStatus((Floor.MoveStatus)0);
        BarObj.SetActive(false);
    }
}
