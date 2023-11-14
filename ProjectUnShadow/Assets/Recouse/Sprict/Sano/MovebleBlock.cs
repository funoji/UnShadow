using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovebleBlock : MonoBehaviour
{
    Vector2Int m_Position;

    public enum PushTo
    {
        XtoMinusX,
        MinusXtoX,
        ZtominusZ,
        MinusZtoZ
    }
    void GetPlayerTouch(PushTo pushFrom)
    {
        FloorController _floorController = GetComponent<FloorController>();
        m_Position = _floorController.GetScriptPos(GetComponent<Floor>());
        Dictionary<PushTo, Action> actions = new Dictionary<PushTo, Action>
        {
            { PushTo.XtoMinusX, () =>
               {
                 if(_floorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Right)).Item1)
                 {
                     _floorController.SetTargetRole(m_Position.x -1,m_Position.y, Floor.FloorRoles.MoveableBlock);
                 }
               }
            },
            { PushTo.MinusXtoX, () =>
               {
                if(_floorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Right)).Item1)
                   {
                     _floorController.SetTargetRole(m_Position.x -1,m_Position.y, Floor.FloorRoles.MoveableBlock);
                   }
               }
            },
            { PushTo.MinusZtoZ, () =>
               {
                // FrontToBack‚Ìê‡‚Ìˆ—
               }
            },
            { PushTo.ZtominusZ, () =>
               {
                // BackToFront‚Ìê‡‚Ìˆ—
               }
            }
        };

        if (actions.ContainsKey(pushFrom))
        {
            actions[pushFrom]();
        }
        else
        {
            // –¢’m‚Ì’l‚Ìê‡‚Ìˆ—
        }
    }
}
