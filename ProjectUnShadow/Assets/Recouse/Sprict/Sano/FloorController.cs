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
    [SerializeField] GameObject NULLObj;
    Floor.FloorRoles[][] floorComponent;
    GameObject[][] floorObj;

    // Start is called before the first frame update
    void Start()
    {
        int countOfChilds = 0;

        // 番兵生成のため、サイズを拡張して初期化
        floorComponent = new Floor.FloorRoles[Hori + 2][];
        floorObj = new GameObject[Hori][];
        for (int i = 0; i < Hori + 2; i++)
        {
            floorComponent[i] = new Floor.FloorRoles[ver + 2];
        }

        //左右の番兵
        for (int i = 0; i < Hori + 2; i++)
        {
            floorComponent[i][0] = Floor.FloorRoles.NULL;
            floorComponent[i][ver + 1] = Floor.FloorRoles.NULL;
           // floorObj[i][0] = GameObject.Instantiate(NULLObj);
           // floorObj[i][ver + 1] = GameObject.Instantiate(NULLObj);
        }

        //上下の番兵
        for (int i = 0; i < ver + 2; i++)
        {
            floorComponent[0][i] = Floor.FloorRoles.NULL;
            floorComponent[Hori + 1][i] = Floor.FloorRoles.NULL;
            //floorObj[0][i] = GameObject.Instantiate(NULLObj);
            //floorObj[Hori][i] = GameObject.Instantiate(NULLObj);
        }

        // 各Floorのロールを取得し配列に格納
        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                //floorObj[Hi][Vi] = transform.GetChild(countOfChilds).gameObject;
                floorComponent[Hi][Vi] = transform.GetChild(countOfChilds).GetComponent<Floor>().GetRoles();
                countOfChilds++;
            }
        }

        StratPos();
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

        //if (floorObj[targetHori][targetVer].CompareTag("CanStep")) return true;
        if (floorComponent[targetHori][targetVer] == Floor.FloorRoles.Normal) return true;

        else return false;
    }

    public int[][] StratPos()
    {
        List<int[]> stratPosition = new List<int[]>();

        for (int Hi = 1; Hi <= Hori; Hi++)
        {
            for (int Vi = 1; Vi <= ver; Vi++)
            {
                if (floorComponent[Hi][Vi] == Floor.FloorRoles.Start)
                {
                    int[] position = new int[] { Hi, Vi };
                    stratPosition.Add(position);
                    Debug.Log(Hi);
                    Debug.Log(Vi);
                    break;
                }
            }
        }
        return stratPosition.ToArray();
    }
    public Floor.FloorRoles GetCurrentRole(int playerHori, int playerVer)
    {
        return floorComponent[playerHori][playerVer];
    }
}