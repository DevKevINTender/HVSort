using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SessionCore;
public class PartSawpCnt : MonoBehaviour
{
    private PartSawpComplete partSawpComplete;
    public void InitControler(PartSawpComplete partSawpComplete)
    {
        this.partSawpComplete = partSawpComplete;
    }
    public bool PartSwap(BoxCom fromBox, BoxCom toBox)
    {
        if ((CheckFreeSlots(toBox) && FullFreeSlots(toBox)) || (CheckFreeSlots(toBox) && TheSamePartColor(fromBox, toBox)))
        {
            PartCom swapPart = fromBox.GetFirstPart();
            fromBox.RemoveOldPart(swapPart);
            toBox.AddNewPart(swapPart);
            partSawpComplete?.Invoke(fromBox, toBox, swapPart);
            PartSwap(fromBox,toBox);
        }
        return true;
    }
    private bool CheckFreeSlots(BoxCom toBox)
    {
        return toBox.isFreeSlot();
    }
    private bool TheSamePartColor(BoxCom fromBox, BoxCom toBox)
    {
        return fromBox.GetFirstPart()?.partColor == toBox.GetFirstPart()?.partColor ? true : false;
    }

    private bool FullFreeSlots(BoxCom toBox)
    {
        return toBox.GetFirstPart() == null ? true : false;
    }
    
    
}
