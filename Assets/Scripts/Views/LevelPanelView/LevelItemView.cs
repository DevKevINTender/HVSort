using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.LevelsSO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static LevelPanelView;
public class LevelItemView : MonoBehaviour, IPointerClickHandler
{
    private SelectLevel selectLevel;
    private LevelScrObj levelScrObj;

    [SerializeField] private Text levelIdText;
    [SerializeField] private Image levelItemImage;
    
    [SerializeField] private Sprite openedLevel;
    [SerializeField] private Sprite closedLevel;
    [SerializeField] private Sprite selectedLevel;
    public void InitView(LevelScrObj levelScrObj, SelectLevel selectLevel)
    {
        this.selectLevel = selectLevel;
        this.levelScrObj = levelScrObj;
        levelIdText.text = levelScrObj.id + 1 + "";
        UpdateView();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        selectLevel?.Invoke(levelScrObj.id);
    }

    public void UpdateView()
    {
        if (LevelsCnt.LevelIsOpened(levelScrObj.id))
        {
            if (levelScrObj.id == LevelsCnt.GetCurrentLevelID())
            {
                levelItemImage.sprite = selectedLevel;
            }
            else
            {
                levelItemImage.sprite = openedLevel;
            }
           
        }
        else
        {
            levelItemImage.sprite = closedLevel;
        }
    }
}
