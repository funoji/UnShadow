using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class MovebleBlock : MonoBehaviour
{
    public Vector2Int m_Position;
    [SerializeField] FloorController m_FloorController;
    [SerializeField] cubeSadow shadowController;
    Animator Playeranimation;
    Floor m_floor;
    Vector3 BloackPos;
    private float moveSpeed=1.0f;

    public enum PushTo
    {
        XtoMinusX,
        MinusXtoX,
        ZtominusZ,
        MinusZtoZ
    }
    private void Start()
    {
        m_FloorController = GameObject.Find("CreateStage").GetComponent<FloorController>();
        m_floor = GetComponentInParent<Floor>();
        m_Position = m_FloorController.GetScriptPos(m_floor);
        m_FloorController.SetTargetStaus(m_Position.x, m_Position.y, Floor.MoveStatus.CantStep);
        BloackPos = new Vector3(m_Position.x, 0, m_Position.y);
        Playeranimation = GameObject.Find("player_rig3").GetComponent<Animator>();
        Debug.Log(m_Position);
    }
    public void GetPlayerTouch(PushTo pushFrom)
    {

        Dictionary<PushTo, Action> actions = new Dictionary<PushTo, Action>
        {
            { PushTo.ZtominusZ, () =>
               {
                 if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Up)).Item1)
                 {

                       //Playeranimation.SetBool("Pushing",true);
                      m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.x -= 1;
                      m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.z +=1;
                        StartCoroutine(MoveTowardsTarget(new Vector3(0, 0, 1)));
                 }
               }
            },
            { PushTo.MinusZtoZ, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Down)).Item1)
                   {
                     
                       m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.x += 1;
                       m_FloorController.SetTargetStaus(m_Position.x ,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.z -= 1;
                       StartCoroutine(MoveTowardsTarget(new Vector3(0, 0, -1)));
                   }
               }
            },
            { PushTo.MinusXtoX, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Right)).Item1)
                   {
                       //Playeranimation.SetBool("Pushing",true);
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.y += 1;
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.x += 1;
                      StartCoroutine(MoveTowardsTarget(new Vector3(1, 0, 0)));
                   }
               }
            },
            { PushTo.XtoMinusX, () =>
               {
                if(m_FloorController.CanMove(m_Position.x,m_Position.y,(FloorController.PlayerMovable.Left)).Item1)
                   {
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CanStep);
                       m_Position.y -= 1;
                     m_FloorController.SetTargetStaus(m_Position.x,m_Position.y, Floor.MoveStatus.CantStep);
                       BloackPos.x -=1;
                       StartCoroutine(MoveTowardsTarget(new Vector3(-1, 0, 0)));
                   }
               }
            }
        };

        if (actions.ContainsKey(pushFrom))
        {
            Playeranimation.SetBool("Pushing", true);
            actions[pushFrom]();
        }
        else
        {
            // ���m�̒l�̏ꍇ�̏���
        }

    }
    private IEnumerator MoveTowardsTarget(Vector3 direction)
    {
        Vector3 targetPosition = transform.position + direction;
        shadowController.MoveShadow(direction);
        while (transform.position != targetPosition)
        {   
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        
        // ������ m_Position ���X�V����K�v�����邩������܂���
        // m_Position �̍X�V������ǉ����Ă�������
        yield return null;
    }
}
