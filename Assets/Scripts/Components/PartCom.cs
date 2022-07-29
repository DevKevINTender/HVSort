using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartCom : MonoBehaviour
{
    [SerializeField] private PartTypeCom partTypeCom;
    [SerializeField] private List<PartTypeCom> partTypeComListPb = new List<PartTypeCom>();
    [SerializeField] private PartAnim partAnim;
    public int weight;
    public PartColor partColor;
    public PartType partType;
    public int id;
    public void InitComponent(PartColor partColor, int id)
    {
        this.id = id;
        this.partColor = partColor;
    }

    public void SetPart(PartType partType)
    {
        this.partType = partType;
        partTypeCom = Instantiate(partTypeComListPb[partTypeId[partType]], transform);
        partTypeCom.InitComponent(partColorColor32[partColor]);
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
    public Dictionary<PartColor, Color32> partColorColor32 = new Dictionary<PartColor, Color32>()
    {
        {PartColor.Red, new Color32(254, 39, 18,255)},
        {PartColor.Green, new Color32(240, 87, 0,255)},
        {PartColor.Orange,  new Color32(251, 153, 2,255)},
        {PartColor.Yellow,  new Color32(250, 188, 3,255)},
        {PartColor.Pink, new Color32(167, 25, 75,255)},
        {PartColor.Violet,  new Color32(134, 2, 176,255)},
        {PartColor.Lime,  new Color32(62, 1, 164,255)},
        {PartColor.Blue,  new Color32(2, 71, 254,255)},
        
    };
    
    [Serializable]
    public enum PartColor
    {
        Red,
        Green,
        Orange,
        Blue,
        Pink,
        Violet,
        Lime,
        Yellow
    }
    
    public enum PartType
    {
        Head,
        Body,
        Leg,
        Arm
        
    }


}
