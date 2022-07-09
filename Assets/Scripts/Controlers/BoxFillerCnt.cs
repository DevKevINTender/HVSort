using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxFillerCnt : MonoBehaviour
{
    public List<PartCom> partList = new List<PartCom>();
    public PartCom partComPb;
    

    public List<BoxCom> FillBoxListRandomGeneration(List<BoxCom> boxListToFill, int colorCount, int freeBoxCount)
    {
        partList = GenerateFillPartList(colorCount);
        while(partList.Count > 0)
        {
            int randomId = Random.Range(0, partList.Count);
            PartCom randomPart = partList[randomId];
            BoxCom randomBox = GetRandomBoxWithFreeSlot(boxListToFill, colorCount);
            randomBox.AddNewPart(randomPart);
            partList.RemoveAt(randomId);
        }
        return null;
    }

    public BoxCom GetRandomBoxWithFreeSlot(List<BoxCom> boxListToFill, int colorCount)
    {
        List<BoxCom> newBoxComList = new List<BoxCom>();
        for (int i = 0; i < colorCount; i++)
        {
            if(boxListToFill[i].isFreeSlot()) newBoxComList.Add(boxListToFill[i]);
        }

        return newBoxComList[Random.Range(0, newBoxComList.Count)];
    }

    public List<PartCom> GenerateFillPartList(int colorCount)
    {
        List<PartCom> newPartList = new List<PartCom>();
        for (int i = 0; i < colorCount; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                PartCom newPartCom = Instantiate(partComPb);
                newPartCom.InitComponent((PartCom.PartColor)i, i * 1 + j * 10);
                newPartList.Add(newPartCom);
            }
        }

        return newPartList;
    }
}
