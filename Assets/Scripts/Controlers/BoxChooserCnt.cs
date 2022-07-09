using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SessionCore;

public class BoxChooserCnt : MonoBehaviour
{

    private BothBoxDel boxsChoosed;
    
    public BoxCom currentBox;

    public void InitControler(BothBoxDel boxsChoosed)
    {
        this.boxsChoosed = boxsChoosed;
        currentBox = null;
    }
    
    public void ChooseBox(BoxCom newBox)
    {
        BoxCom fromBox = null;
        BoxCom toBox = null;
        if (currentBox == null)
        {
            currentBox = newBox;
            newBox.BoxChoosen();
        }
        else
        {
            if (currentBox.boxId == newBox.boxId)
            {
                currentBox = null;
                newBox.BoxBack();
            }
            else
            {
                boxsChoosed?.Invoke(currentBox, newBox);
                currentBox.BoxBack();
                currentBox = null;
            }
        }
       
    }
}
