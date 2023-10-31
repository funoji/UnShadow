using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorController : MonoBehaviour
{
    public enum PlayerMovable
    {
        Up,
        Right,
        Down,
        Left
    }

    [SerializeField] int Hori;
    [SerializeField] int ver;
    [SerializeField] GameObject NULLObj;
    Floor [][] floorComponent;

    // Start is called before the first frame update
    void Awake()
    {
        int countOfChilds = 0;

        // �ԕ������̂��߁A�T�C�Y���g�����ď�����
        floorComponent = new Floor[Hori + 2][];
        for (int i = 0; i < Hori + 2; i++)
        {
            floorComponent[i] = new Floor[ver + 2];
        }

        // �eFloor�̃��[�����擾���z��Ɋi�[
        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                floorComponent[Hi][Vi] = this.transform.GetChild(countOfChilds).GetComponent<Floor>();
                countOfChilds++;
            }
        }
    }

    static public readonly Dictionary<PlayerMovable, Vector2Int> MoveVector = new Dictionary<PlayerMovable, Vector2Int>()
    {
        { PlayerMovable.Right, new Vector2Int(1, 0) },
        { PlayerMovable.Left, new Vector2Int(-1, 0) },
        { PlayerMovable.Up, new Vector2Int(0, 1) },
        { PlayerMovable.Down, new Vector2Int(0, -1) }
    };

    public (bool, Vector2Int) CanMove(int playerHori, int playerVer, PlayerMovable playerMovable)
    {
        if (!MoveVector.TryGetValue(playerMovable, out Vector2Int offset))
        {
            throw new System.NotImplementedException("ERROR���ɂ�");
        }

        int targetHori = playerHori + offset.y;
        int targetVer = playerVer + offset.x;
        Vector2Int FeaacherPos = new(targetHori, targetVer);

        if (floorComponent[targetHori][targetVer] == null) return (false, FeaacherPos);
        if (floorComponent[targetHori][targetVer].GetMoveStatus() == Floor.MoveStatus.CanStep)
        {
            Vector2Int PlayerPos = FeaacherPos;
            return (true, PlayerPos);
        }
        else return (false, FeaacherPos);
    }

    public Vector2Int StratPos()
    {

        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                if (floorComponent[Hi][Vi].GetRoles() == Floor.FloorRoles.Start)
                {
                    Vector2Int position = new(Hi, Vi);
                    return position;
                }
            }
        }
        throw new Exception("None StartObj");
    }
    public Floor.FloorRoles GetCurrentRole(int playerHori, int playerVer)
    {
        return floorComponent[playerHori][playerVer].GetRoles();
    }  
    public void SetTargetRole(int playerHori, int playerVer ,Floor.FloorRoles roles)
    {
        floorComponent[playerHori][playerVer].SetRole(roles);
    }
    public Vector2Int GetScriptPos(Floor TargetSprict)
    {
        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                if (floorComponent[Hi][Vi] == TargetSprict)
                {
                    Vector2Int position = new(Hi, Vi);
                    return position;
                }
            }
        }
       throw new Exception("there is none script");

    }
}