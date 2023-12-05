using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class MovebleBlock : MonoBehaviour
{
    Vector2Int m_Position;
    [SerializeField] FloorController m_FloorController;
    Floor m_floor;

    public enum PushTo
    {
        XtoMinusX,
        MinusXtoX,
        ZtominusZ,
        MinusZtoZ
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            GetPlayerTouch(PushTo.MinusXtoX);
            //Debug.Log("getpush");
        }
    }

    private void Start()
    {
        m_floor = GetComponentInParent<Floor>();
        m_Position = m_FloorController.GetScriptPos(m_floor);

        Debug.Log(m_Position);
    }
    void GetPlayerTouch(PushTo pushFrom)
    {
        
        Dictionary<PushTo, Action> actions = new Dictionary<PushTo, Action>
        {
            { PushTo.XtoMinusX, () =>
               {
                 if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Left)).Item1)
                 {
                      m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                      m_FloorController.SetTargetStaus(m_Position.x + 1,m_Position.y, Floor.MoveStatus.CantStep);
                 }
               }
            },
            { PushTo.MinusXtoX, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Right)).Item1)
                   {
                       m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_FloorController.SetTargetStaus(m_Position.x + 1,m_Position.y, Floor.MoveStatus.CantStep);
                   }
               }
            },
            { PushTo.MinusZtoZ, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Up)).Item1)
                   {
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y + 1, Floor.MoveStatus.CantStep);
                   }
               }
            },
            { PushTo.ZtominusZ, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Down)).Item1)
                   {
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y - 1, Floor.MoveStatus.CantStep);
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
            // ñ¢ímÇÃílÇÃèÍçáÇÃèàóù
        }
    }
}
