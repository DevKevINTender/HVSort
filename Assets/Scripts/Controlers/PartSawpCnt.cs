using System.Collections;
using System.Collections.Generic;
using Controlers;
using UnityEngine;
using static SessionCore;
public class PartSawpCnt : MonoBehaviour
{
    private PartSawpComplete partSawpComplete;
    private bool swapMoreWhenOne;
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
            swapMoreWhenOne = true;
            AudioCnt audioCnt = FindObjectOfType<AudioCnt>();
            audioCnt.CreateNewAudioElement(1);
            PartSwap(fromBox,toBox);
        }
        else
        {
            if (swapMoreWhenOne)
            {
                swapMoreWhenOne = false;
            }
            else
            {
                AudioCnt audioCnt = FindObjectOfType<AudioCnt>();
                audioCnt.CreateNewAudioElement(4);
                toBox.boxAnim.SwapMistacke();
            }
            
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
