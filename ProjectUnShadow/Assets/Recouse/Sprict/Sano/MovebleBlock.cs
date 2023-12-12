using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class MovebleBlock : MonoBehaviour
{
    Vector2Int m_Position;
    [SerializeField] FloorController m_FloorController;
    Floor m_floor;
    Vector3 BloackPos;

    public enum PushTo
    {
        XtoMinusX,
        MinusXtoX,
        ZtominusZ,
        MinusZtoZ
    }
    private void Start()
    {
        m_floor = GetComponentInParent<Floor>();
        m_Position = m_FloorController.GetScriptPos(m_floor);
        m_FloorController.SetTargetStaus(m_Position.x, m_Position.y, Floor.MoveStatus.CantStep);
        BloackPos = new Vector3(m_Position.x, 0, m_Position.y);

        Debug.Log(m_Position);
    }
    public void GetPlayerTouch(PushTo pushFrom)
    {

        Dictionary<PushTo, Action> actions = new Dictionary<PushTo, Action>
        {
            { PushTo.ZtominusZ, () =>
               {
                 if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Left)).Item1)
                 {
                      m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.x += 1;
                      m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.z +=1;
                       transform.position = BloackPos;
                 }
               }
            },
            { PushTo.MinusZtoZ, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Right)).Item1)
                   {
                       m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.x -= 1;
                       m_FloorController.SetTargetStaus(m_Position.x ,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.z -= 1;
                       transform.position = BloackPos;
                   }
               }
            },
            { PushTo.MinusXtoX, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Up)).Item1)
                   {
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.y += 1;
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.x += 1;
                       transform.position = BloackPos;
                   }
               }
            },
            { PushTo.XtoMinusX, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Down)).Item1)
                   {
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.y -= 1;
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.x -=1;
                       transform.position = BloackPos;
                   }
               }
            }
        };

        if (actions.ContainsKey(pushFrom))
        {
            actions[pushFrom]();
        }
        else
        {
            // 未知の値の場合の処理
        }
    }
}
