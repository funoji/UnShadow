using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public GameObject[] Walls;
    public testmove TestMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (TestMove.Up == 0)
            {
                Walls[0].gameObject.SetActive(false);
            }
            else
            { Walls[0].gameObject.SetActive(true); }

            if (TestMove.Up == 1)
            {
                Walls[1].gameObject.SetActive(false);
            }
            else
            { Walls[1].gameObject.SetActive(true); }

            if (TestMove.Up == 2)
            {
                Walls[2].gameObject.SetActive(false);
            }
            else
            { Walls[2].gameObject.SetActive(true); }

            if (TestMove.Up == 3)
            {
                Walls[3].gameObject.SetActive(false);
            }
            else
            { Walls[3].gameObject.SetActive(true); }
    }
}
