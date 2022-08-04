using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects;
using ScriptableObjects.LevelsSO;
using Unity.VisualScripting;
using UnityEngine;

public class BoxFillerCnt : MonoBehaviour
{
    public List<PartCom> partList = new List<PartCom>();
    public PartCom partComPb;

    public void FillBoxListFromLevel(List<BoxCom> boxListToFill, LevelScrObj level)
    {
        for (int i = 0; i < level.list.Count; i++)
        {
            Colum colum = level.list[i];
            for (int j = 0; j < colum.list.Count; j++)
            {
                PartCom newPartCom = Instantiate(partComPb);
                newPartCom.InitComponent(colum.list[j], i * 1 + j * 10);
                boxListToFill[i].AddNewPart(newPartCom);
                partList.Add(newPartCom);
            }
        }

        SetPartType(FindUniqueColorItemList(partList));
    }

    private List<PartCom> FindUniqueColorItemList(List<PartCom> partList)
    {
        List<PartCom> uniqueColorPartList = new List<PartCom>(); 
        foreach (var item in partList)
        {
            bool isUnique = true;
            foreach (var uniqueItem in uniqueColorPartList)
            {
                if (uniqueItem.partColor == item.partColor) isUnique = false;
            }
            if(isUnique) uniqueColorPartList.Add(item);
        }

        return uniqueColorPartList;
    }

    private void SetPartType(List<PartCom> uniqueColorPartList)
    {
        foreach (var uniqueItem in uniqueColorPartList)
        {
            int type = 0;
            foreach (var item in partList)
            {
                if (uniqueItem.partColor == item.partColor)
                {
                    item.SetPart((PartCom.PartType)type);
                    type++;
                }
            }
        }
    }
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
                newPartCom.InitComponent((PartColorPacksCnt.PartColor)i, i * 1 + j * 10);
                newPartList.Add(newPartCom);
            }
        }

        return newPartList;
    }
}
