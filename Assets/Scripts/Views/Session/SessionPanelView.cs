using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;
using UnityEngine.UI;
using Views.Result.DailyPanelView;

public class SessionPanelView : MonoBehaviour
{
    public Text currentLevelText;
    public MainMenuPanelVIew mainMenuPanel;
    public DailyInfoView DailyInfoView;
    
    [SerializeField] private Image backGround;
    
    public void InitView()
    {
        currentLevelText.text = LevelsCnt.GetCurrentLevelID() + 1 +"";
        UpdateBackGround();
        DailyInfoView.InitView();
    }

    public void OpenMainMenu()
    {
        mainMenuPanel.gameObject.SetActive(true);
        mainMenuPanel.InitView();
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
}
