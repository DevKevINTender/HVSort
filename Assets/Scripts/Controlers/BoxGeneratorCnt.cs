    using System.Collections;
using System.Collections.Generic;
using System.Linq;
    using ControlersData;
    using UnityEngine;
using static SessionCore;
public class BoxGeneratorCnt : MonoBehaviour
{
    //generator settings
    [Header("Generator Settings:")]
    [SerializeField] private Vector2 spawnStartPos;
    [SerializeField] private int maxColumnInRow;
    [SerializeField] private float step;
    [SerializeField] private BoxCom boxComPb;
    [SerializeField] private int totalMaxColum;
    [Header("Generator Result:")]
    public List<BoxCom> boxList = new List<BoxCom>();
    public List<BoxCom> extraBoxList = new List<BoxCom>();
    public List<BoxCom> activeBoxList = new List<BoxCom>();

    public Transform platfromForBoxs;
    
    public void GenerateNewBoxList(int colorCount, int freeBoxCount, BoxDel boxChoose, BoxGeneratorSettingsDel settings)
    {
        int countColumn = 0;
        int countRow = 0;
        
        for (int i = 0; i < totalMaxColum; i++)
        {
            Vector2 newPos = new Vector2(spawnStartPos.x + countColumn * step,  spawnStartPos.y + (-countRow * step * 5));
            BoxCom newBoxCom = Instantiate(boxComPb, newPos, Quaternion.identity);
            newBoxCom.transform.SetParent(platfromForBoxs);
            newBoxCom.InitComponent(boxChoose, i, countRow);
            boxList.Add(newBoxCom);
            countColumn++;
            if (i < (freeBoxCount + colorCount))
            {
                activeBoxList.Add(newBoxCom);
            }
            else
            {
                extraBoxList.Add(newBoxCom);
            }
           
            if (countColumn == maxColumnInRow)
            {
                countColumn = 0;
                countRow++;
            }
        }
        AlignBoxes(activeBoxList);
        HideExtra(extraBoxList);
        UpdatePlatformForBoxs();
        
        settings?.Invoke(boxList, activeBoxList,extraBoxList);
    }

    private void AlignBoxes(List<BoxCom> boxComList)
    {
        List<BoxCom> rowBox = new List<BoxCom>();
        for (int i = 0; i <boxComList.Count; i ++)
        {
            rowBox.Add(boxComList[i]);
            if(rowBox.Count == maxColumnInRow || i == (boxComList.Count - 1))
            {
                float newX = -(rowBox.Count - 1) * (step / 2);
                for (int j = 0; j < rowBox.Count; j++)
                {
                    rowBox[j].transform.position = new Vector2(newX + j * step,  rowBox[j].transform.position.y);
                }
                rowBox.Clear();
            }
        }
    }

    private void UpdatePlatformForBoxs()
    {
        if (activeBoxList.Count / (float) maxColumnInRow > 1)
        {
            platfromForBoxs.transform.position = new Vector3(0,0,0);
        }
        else
        {
            platfromForBoxs.transform.position = new Vector3(0,-3,0);
        }
    }
    private void HideExtra(List<BoxCom> boxComList)
    {
        foreach (var item in boxComList)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void ShowExtra()
    {
        if (extraBoxList.Count > 0)
        {
            DailyCnt.AddPointToDailyItemComplete(4,1);
            BoxCom showBox = extraBoxList[0];
            extraBoxList.Remove(showBox);
            activeBoxList.Add(showBox);
            showBox.gameObject.SetActive(true);
            AlignBoxes(activeBoxList);
            UpdatePlatformForBoxs();
        }
    }
    
}
