using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.LevelsSO;
using UnityEngine;
using static LevelPanelView;
public class LevelPageView : MonoBehaviour
{
    public LevelItemView levelItemViewPb;
    public List<LevelItemView> levelItemList = new List<LevelItemView>();
    public void InitView(List<LevelScrObj> levelList, SelectLevel selectLevel)
    {
        foreach (var item in levelList)
        {
            LevelItemView newLevelItemView =  Instantiate(levelItemViewPb, transform);
            newLevelItemView.InitView(item, selectLevel);
            levelItemList.Add(newLevelItemView);
        }
    }
    
    public void UpdateView()
    {
        foreach (var item in levelItemList)
        {
            item.UpdateView();
        }
    }
    
    
}
