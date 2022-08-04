using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;

public class PartCom : MonoBehaviour
{
    [SerializeField] private PartTypeCom partTypeCom;
    [SerializeField] private List<PartTypeCom> partTypeComListPb = new List<PartTypeCom>();
    [SerializeField] private PartAnim partAnim;
    public int weight;
    public PartColorPacksCnt.PartColor partColor;
    public PartType partType;
    public int id;
    public void InitComponent(PartColorPacksCnt.PartColor partColor, int id)
    {
        this.id = id;
        this.partColor = partColor;
    }

    public void SetPart(PartType partType)
    {
        this.partType = partType;
        partTypeCom = Instantiate(partTypeComListPb[partTypeId[partType]], transform);
        partTypeCom.InitComponent(PartColorPacksCnt.GetCurrentLevelPack()[partColor]);
    }

    public void MoveToNewPosition(BoxCom boxCom, int id)
    {
        partAnim.Teleport(boxCom, id);
    }

    public void MoveToCurrentSlot(BoxCom boxCom, int i)
    {
        partAnim.MoveToCurrentSlot(boxCom, i);
    }

    public void RestartLevel(BoxCom newBox)
    {
        partAnim.RestartLevel(newBox);
    }
    private Dictionary<PartType, int> partTypeId = new Dictionary<PartType, int>()
    {
        {PartType.Head, 0},
        {PartType.Leg, 1},
        {PartType.Arm,  2},
        {PartType.Body, 3},

    };
   
    
    public enum PartType
    {
        Head,
        Body,
        Leg,
        Arm
        
    }


}
