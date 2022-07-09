using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSawpCnt : MonoBehaviour
{
    // Start is called before the first frame update
    public bool PartSwap(BoxCom fromBox, BoxCom toBox)
    {
        if ((CheckFreeSlots(toBox) && FullFreeSlots(toBox)) || (CheckFreeSlots(toBox) && TheSamePartColor(fromBox, toBox)))
        {
            PartCom swapPart = fromBox.GetFirstPart();
            fromBox.RemoveOldPart(swapPart);
            toBox.AddNewPart(swapPart);
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
