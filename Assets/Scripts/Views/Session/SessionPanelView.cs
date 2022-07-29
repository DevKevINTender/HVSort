using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;
using UnityEngine.UI;

public class SessionPanelView : MonoBehaviour
{
    public Text currentLevelText;
    public MainMenuPanelVIew mainMenuPanel;
    
    [SerializeField] private Image backGround;
    
    public void InitView()
    {
        currentLevelText.text = LevelsCnt.GetCurrentLevelID() + 1 +"";
        UpdateBackGround();
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
