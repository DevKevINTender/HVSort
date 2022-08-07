using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;
using UnityEngine.UI;
using Views;
using Views.MainMenuPanelView;

public class MainMenuPanelVIew : MonoBehaviour
{
    [SerializeField] private SkinPanelView skinPanelViewPb;
    [SerializeField] private AnimationPanelView animationPanelViewPb;
    [SerializeField] private BackGroundPanelView backGroundPanelViewPb;
    
    [SerializeField] private SkinPanelView skinPanelView;
    [SerializeField] private AnimationPanelView animationPanelView;
    [SerializeField] private BackGroundPanelView backGroundPanelView;
    [SerializeField] private SettingsPanelView settingsPanelView;
    
    [SerializeField] private Transform skinPanelViewPos;
    [SerializeField] private Transform animationPanelViewPos;
    [SerializeField] private Transform backGroundPanelViewPos;
    
    [SerializeField] private Text coinsCount;
    [SerializeField] private Text currentPanel;

    [SerializeField] private GameObject currentPanelObj;
    [SerializeField] private Image backGround;
    [SerializeField] private GameObject currentPanelButton;
    
    [SerializeField] private GameObject skinPanelButton;
    [SerializeField] private GameObject animationPanelButton;
    [SerializeField] private GameObject backGroundPanelButton;
    [SerializeField] private GameObject settingsPanelButton;
    public void InitView()
    {
        coinsCount.text = CoinsCnt.GetCoinsCount() + "";
       
        ShowBackGroundPanel();
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
    
    public void ShowSkinPanel()
    {
        Destroy(currentPanelObj);
        skinPanelView = Instantiate(skinPanelViewPb, skinPanelViewPos);
        skinPanelView.InitView();
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonAnim>().Decrease();
        skinPanelButton.GetComponent<ButtonAnim>().Increase();
        currentPanelObj = skinPanelView.gameObject;
        currentPanelButton = skinPanelButton;
        currentPanel.text = "Скины";
    }

    public void ShowBackGroundPanel()
    {
        Destroy(currentPanelObj);
        backGroundPanelView = Instantiate(backGroundPanelViewPb, backGroundPanelViewPos);
        backGroundPanelView.InitView();
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonAnim>().Decrease();
        backGroundPanelButton.GetComponent<ButtonAnim>().Increase();
        currentPanelObj = backGroundPanelView.gameObject;
        currentPanelButton = backGroundPanelButton;
        currentPanel.text = "Фоны";
    }
    
    public void ShowAnimationPanel()
    {
        Destroy(currentPanelObj);
        animationPanelView = Instantiate(animationPanelViewPb, animationPanelViewPos);
        animationPanelView.InitView();
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonAnim>().Decrease();
        animationPanelButton.GetComponent<ButtonAnim>().Increase();
        currentPanelObj = animationPanelView.gameObject;
        currentPanelButton = animationPanelButton;
        currentPanel.text = "Анимации";
    }

    public void ShowSettingsPanel()
    {
        Destroy(currentPanelObj);
        if(currentPanelButton) currentPanelButton.GetComponent<ButtonAnim>().Decrease();
        settingsPanelButton.GetComponent<ButtonAnim>().Increase();
        currentPanelButton = settingsPanelButton;
        currentPanel.text = "Настройки";
        
    }
    
    public void CloseMainMenuPanel()
    {
        Destroy(currentPanelObj);
        gameObject.SetActive(false);
    }
}
