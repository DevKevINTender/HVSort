using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionCore : MonoBehaviour
{
    public delegate void BothBoxDel(BoxCom fromBox, BoxCom toBox);
    public delegate void BoxMoveCompleted();
    public delegate void BoxDel(BoxCom boxCom);
    public delegate void PartSawpComplete(BoxCom fromBox, BoxCom toBox, PartCom movedPart);

    public delegate void BoxGeneratorSettingsDel(List<BoxCom> newBoxList, List<BoxCom> activeBoxList,
        List<BoxCom> extraBoxList);

    public delegate void SelectLevelDel();

    public delegate void CompleteLevelDel();
    
    public BoxGeneratorCnt boxGeneratorCnt;
    public BoxFillerCnt boxFillerCnt;
    public BoxChooserCnt boxChooserCnt;
    public PartSawpCnt partSawpCnt;
    public BackMoveCnt backMoveCnt;
    public LevelCompleteCnt levelCompleteCnt;
    public SessionSettingsCnt sessionSettingsCnt;

    public SessionPanelView SessionPanelView;
    public LevelPanelView LevelPanelView;
    public MainMenuPanelVIew MainMenuPanelVIew;
    
    public GameObject restartPanell;
    
    void Start()
    {
        PlayerPrefs.SetInt("BackMoveCount",10);
        PlayerPrefs.SetInt("Coins", 5000);
        DOTween.Init();
        
        DailyCnt.InitControler();
        
        sessionSettingsCnt.InitControler();
        partSawpCnt.InitControler(SwapCompleted);
        boxChooserCnt.InitControler(ChooseBothBoxes);
        backMoveCnt.InitContoler(CheckComposeBoxes);
        levelCompleteCnt.InitControler(sessionSettingsCnt.coloredBoxCount, CompleteLevel);
        
        SessionPanelView.InitView();

        boxGeneratorCnt.GenerateNewBoxList(sessionSettingsCnt.coloredBoxCount, sessionSettingsCnt.freeBoxCount, ChooseBox, BoxGeneratorSetSessionSettings);
        boxFillerCnt.FillBoxListFromLevel(sessionSettingsCnt.boxList,sessionSettingsCnt.LevelSO);
    }

    public void BoxGeneratorSetSessionSettings(List<BoxCom> newBoxList, List<BoxCom> activeBoxList, List<BoxCom> extraBoxList )
    {
        sessionSettingsCnt.boxList = newBoxList;
        sessionSettingsCnt.activeBoxList = activeBoxList;
        sessionSettingsCnt.extraBoxList = extraBoxList;
    }
    public void SwapCompleted(BoxCom fromBox, BoxCom toBox, PartCom movePart)
    {
        backMoveCnt.AddMove(fromBox, toBox, movePart);
        CheckComposeBoxes();
    }

    public void CheckComposeBoxes()
    {
        levelCompleteCnt.CheckComposeStates(sessionSettingsCnt.boxList);
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
        restartPanell.SetActive(true);
        foreach (var box in sessionSettingsCnt.boxList)
        {
            foreach (var part in box.list)
            {
                part.RestartLevel(box);
            }
        }

        StartCoroutine(WaitForSceneLoad());
    }
    
    public void CompleteLevel()
    {
        restartPanell.SetActive(true);
        foreach (var box in sessionSettingsCnt.boxList)
        {
            foreach (var part in box.list)
            {
                part.RestartLevel(box);
            }
        }
        LevelsCnt.OpenLevel(LevelsCnt.GetCurrentLevelID() + 1);
        LevelsCnt.SetCurrentLevel(LevelsCnt.GetCurrentLevelID() + 1);
        StartCoroutine(WaitForSceneLoad());
    }
    
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Session");

    }

    public void OpenLevelList()
    {
        LevelPanelView.gameObject.SetActive(true);
        LevelPanelView.InitView(SelectLevel);
    }
    public void CloseLevelList()
    {
        LevelPanelView.gameObject.SetActive(false);
    }
    public void SelectLevel()
    {
        CloseLevelList();
        RestartLevel();
    }

    public void SelectSkin()
    {
        
    }

    public void SelectBackGround()
    {
        
    }
    
    public  void SelectAnimation()
    {}
    
}
