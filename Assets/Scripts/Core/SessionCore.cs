using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionCore : MonoBehaviour
{
    public delegate void BothBoxDel(BoxCom fromBox, BoxCom toBox);
    public delegate void BoxMoveCompleted();
    public delegate void BoxDel(BoxCom boxCom);
    
    public int colorCount;
    public int freeBoxCount;

    public BoxGeneratorCnt boxGeneratorCnt;
    public BoxFillerCnt boxFillerCnt;
    public BoxChooserCnt boxChooserCnt;
    public PartSawpCnt partSawpCnt;
    void Start()
    {
        DOTween.Init();
        List<BoxCom> newBoxList = boxGeneratorCnt.GenerateNewBoxList(colorCount, freeBoxCount, ChooseBox);
        boxFillerCnt.FillBoxListRandomGeneration(newBoxList, colorCount, freeBoxCount);
        boxChooserCnt.InitControler(ChooseBothBoxes);
        Debug.Log("test");
    }

    public void ChooseBothBoxes(BoxCom fromBox, BoxCom toBox)
    {
        Debug.Log("From: " + fromBox.boxId + " To: " +toBox.boxId);
        partSawpCnt.PartSwap(fromBox, toBox);
    }

    public void ChooseBox(BoxCom boxCom)
    {
        boxChooserCnt.ChooseBox(boxCom);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
