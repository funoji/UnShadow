using UnityEngine;

public class Create_Stage : MonoBehaviour
{
    [SerializeField] int StageHori;
    [SerializeField] int StageVer;
    [SerializeField]
    int [][] Stage;

    public enum SelectStageGimmick
    {
        NormalFloor,
        FristHight,
        SecondHight,
        ThridHight,
        SolarPalel
    };

    [SerializeField] SelectStageGimmick[] InthisFloor;
    public Create_Stage()
    {
        for(int i = 0; i< StageHori; i++)
        {
            for (int ii = 0; ii < StageVer; ii++)
            {
                Stage[i][ii] = ii;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // GameObject‚ð•ÛŽ‚·‚é”z—ñ‚Ì¶¬
        GameObject[] Gimmicks = new GameObject[5];

        // Še—v‘f‚ÖŒŸõ‚µŽæ“¾‚µ‚Ä‚«‚½GameObject‚ð‘ã“ü
        Gimmicks[0] = GameObject.Find("NormalFloor");
        Gimmicks[1] = GameObject.Find("FristHight");
        Gimmicks[2] = GameObject.Find("SecondHight");
        Gimmicks[3] = GameObject.Find("ThridHight");
        Gimmicks[4] = GameObject.Find("SolarPalel");

        for (int i = 0; i < StageHori; i++)
        {
            for (int ii = 0; ii < StageVer; ii++)
            {
                GameObject.Instantiate(Gimmicks[(int)InthisFloor[ii]]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
