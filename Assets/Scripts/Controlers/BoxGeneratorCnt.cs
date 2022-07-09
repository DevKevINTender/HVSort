using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SessionCore;
public class BoxGeneratorCnt : MonoBehaviour
{
    //generator settings
    [Header("Generator Settings:")]
    [SerializeField] private Vector2 spawnStartPos;
    [SerializeField] private int maxColumn;
    [SerializeField] private int step;
    [SerializeField] private BoxCom boxComPb;
    [Header("Generator Result:")]
    public List<BoxCom> boxList = new List<BoxCom>();

    public List<BoxCom> GenerateNewBoxList(int colorCount, int freeBoxCount, BoxDel boxChoose)
    {
        int countColumn = 0;
        int countRow = 0;
        for (int i = 0; i < colorCount + freeBoxCount; i++)
        {
            Vector2 newPos = new Vector2(spawnStartPos.x + countColumn * step,  spawnStartPos.y + (-countRow * step * 5));
            BoxCom newBoxCom = Instantiate(boxComPb, newPos, Quaternion.identity);
            newBoxCom.InitComponent(boxChoose, i);
            boxList.Add(newBoxCom);
            
            countColumn++;
            if (countColumn == maxColumn)
            {
                countColumn = 0;
                countRow++;
            }
        }
        return boxList;
    }

    public void InitBoxCom()
    {
       
    }
    
}
