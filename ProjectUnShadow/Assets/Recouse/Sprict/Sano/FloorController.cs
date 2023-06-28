using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorController : MonoBehaviour
{
    public enum PlayerMovable
    {
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField] int Hori;
    [SerializeField] int ver;
    Floor.FloorRoles[][] floorComponent;

    // Start is called before the first frame update
    void Start()
    {
        int countOfChilds = 0;

        // 番兵生成のため、サイズを拡張して初期化
        floorComponent = new Floor.FloorRoles[Hori + 2][];
        for (int i = 0; i < Hori + 2; i++)
        {
            floorComponent[i] = new Floor.FloorRoles[ver + 2];
        }

        //左右の番兵
        for (int i = 0; i < Hori + 2; i++)
        {
            floorComponent[i][0] = Floor.FloorRoles.NULL;
            floorComponent[i][ver + 1] = Floor.FloorRoles.NULL;
        }

        //上下の番兵
        for (int i = 0; i < ver + 2; i++)
        {
            floorComponent[0][i] = Floor.FloorRoles.NULL;
            floorComponent[Hori + 1][i] = Floor.FloorRoles.NULL;
        }

        // 各Floorのロールを取得し配列に格納
        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                floorComponent[Hi][Vi] = transform.GetChild(countOfChilds).GetComponent<Floor>().GetRoles();
                countOfChilds++;
            }
        }
    }

    static readonly Dictionary<PlayerMovable, Vector2Int> MoveVector = new Dictionary<PlayerMovable, Vector2Int>()
    {
        { PlayerMovable.Right, new Vector2Int(1, 0) },
        { PlayerMovable.Left, new Vector2Int(-1, 0) },
        { PlayerMovable.Up, new Vector2Int(0, 1) },
        { PlayerMovable.Down, new Vector2Int(0, -1) }
    };

    public bool CanMove(int playerHori, int playerVer, PlayerMovable playerMovable)
    {
        if (!MoveVector.TryGetValue(playerMovable, out Vector2Int offset))
        {
            throw new System.NotImplementedException("ERRORだにょ");
        }

        int targetHori = playerHori + offset.x;
        int targetVer = playerVer + offset.y;

        return floorComponent[targetHori][targetVer] == Floor.FloorRoles.Normal;
    }

    public Floor.FloorRoles GetCurrentRole(int playerHori, int playerVer)
    {
        return floorComponent[playerHori][playerVer];
    }
}