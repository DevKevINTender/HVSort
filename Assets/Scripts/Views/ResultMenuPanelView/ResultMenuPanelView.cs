using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;
using UnityEngine.UI;

public class ResultMenuPanelView : MonoBehaviour
{
    [SerializeField] private ProgressPanelView progressPanelViewPb;
    [SerializeField] private DailyPanelView dailyPanelViewPb;

    [SerializeField] private ProgressPanelView progressPanelView;
    [SerializeField] private DailyPanelView dailyPanelView;
    
    [SerializeField] private Transform progressPanelViewPos;
    [SerializeField] private Transform dailyPanelViewPos;
    
    
    [SerializeField] private Text coinsCount;
    [SerializeField] private Text currentPanel;

    [SerializeField] private GameObject currentPanelObj;
    [SerializeField] private Image backGround;
    [SerializeField] private GameObject currentPanelButton;
    
    [SerializeField] private GameObject progressPanelButton;
    [SerializeField] private GameObject dailyPanelButton;
   
   
    public void InitView()
    {
        coinsCount.text = CoinsCnt.GetCoinsCount() + "";
       
        ShowProgressPanel();
        UpdateBackGround();
    }

    public void Start()
    {
        BackGroundCnt.SetCurrentBackGroundEvent += UpdateBackGround;
        CoinsCnt.ChangeCoinsEvent += UpdateCoinsText;
    }

    public void OnDestroy()
    {
        BackGroundCnt.SetCurrentBackGroundEvent -= UpdateBackGround;
        CoinsCnt.ChangeCoinsEvent -= UpdateCoinsText;
    }

    public void UpdateCoinsText()
    {
        coinsCount.text = CoinsCnt.GetCoinsCount() + "";
    }
    
    public void UpdateBackGround()
    {
        backGround.sprite = BackGroundCnt.GetCurrentBackGround().backGroundSession;
    }
    
    public void ShowProgressPanel()
    {
        Destroy(currentPanelObj);
        progressPanelView = Instantiate(progressPanelViewPb, progressPanelViewPos);
        progressPanelView.InitView();
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonSizeAnim>().Decrease();
        progressPanelButton.GetComponent<ButtonSizeAnim>().Increase();
        currentPanelObj = progressPanelView.gameObject;
        currentPanelButton = progressPanelButton;
        currentPanel.text = "Прогресс";
    }

    public void ShowDailyPanel()
    {
        Destroy(currentPanelObj);
        dailyPanelView = Instantiate(dailyPanelViewPb, dailyPanelViewPos);
        dailyPanelView.InitView();
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonSizeAnim>().Decrease();
        dailyPanelButton.GetComponent<ButtonSizeAnim>().Increase();
        currentPanelObj = dailyPanelView.gameObject;
        currentPanelButton = dailyPanelButton;
        currentPanel.text = "Ежедневки";
    }

    public void CloseResultMenuPanel()
    {
        Destroy(currentPanelObj);
        gameObject.SetActive(false);
    }
}
