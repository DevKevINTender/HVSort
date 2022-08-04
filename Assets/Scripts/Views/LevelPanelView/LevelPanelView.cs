using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;
using UnityEngine.UI;
using static SessionCore;

public class LevelPanelView : MonoBehaviour
{
    public delegate void SelectLevel(int id);
    
    public LevelPageView currentPage;
    public LevelPageView levelPageViewPb;
    public Transform levelPageSpawnPos;
    private int currentPageId;
    private int pageCount;
    [SerializeField] private int itemOnPage;
    [SerializeField] private Image backGround;
    
    public SelectLevelDel selectLevelDel;
    public void InitView(SelectLevelDel selectLevelDel)
    {
        this.selectLevelDel = selectLevelDel;
        currentPageId =  (int) Math.Floor((double) LevelsCnt.GetCurrentLevelID() / itemOnPage);
        pageCount = (int) Math.Ceiling((double) LevelsCnt.GetLevelCount() / itemOnPage);
        
        currentPage = Instantiate(levelPageViewPb,levelPageSpawnPos);
        currentPage.InitView(LevelsCnt.GetSessionLevelsFromPage(currentPageId, itemOnPage), SelectCurrentLevel);

        UpdateBackGround();
    }
    public void Start()
    {
        BackGroundCnt.SetCurrentBackGroundEvent += UpdateBackGround;
    }

    public void OnDestroy()
    {
        BackGroundCnt.SetCurrentBackGroundEvent -= UpdateBackGround;
    }
    
    public void UpdateBackGround()
    {
        backGround.sprite = BackGroundCnt.GetCurrentBackGround().backGroundSession;
    }
    
    public void NextPage()
    {
        if (currentPageId < pageCount - 1)
        {
            currentPageId++;
            Destroy(currentPage.gameObject);
            currentPage = Instantiate(levelPageViewPb,levelPageSpawnPos);
            currentPage.InitView(LevelsCnt.GetSessionLevelsFromPage(currentPageId, itemOnPage), SelectCurrentLevel);
        }
    }

    public void PreviousPage()
    {
        if (currentPageId > 0)
        {
            currentPageId--;
            Destroy(currentPage.gameObject);
            currentPage = Instantiate(levelPageViewPb,levelPageSpawnPos);
            currentPage.InitView(LevelsCnt.GetSessionLevelsFromPage(currentPageId, itemOnPage), SelectCurrentLevel);
        }
    }

    public void SelectCurrentLevel(int id)
    {
        if (LevelsCnt.LevelIsOpened(id))
        {
            LevelsCnt.SetCurrentLevel(id);
            currentPage.UpdateView();
            selectLevelDel?.Invoke();
        }
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Destroy(currentPage.gameObject);
    }
    
}
