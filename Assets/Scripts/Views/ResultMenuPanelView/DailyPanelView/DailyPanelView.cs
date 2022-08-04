using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.DailySo.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

public class DailyPanelView : MonoBehaviour
{
    [SerializeField] private DailyItemView dailyItemViewPB;
    [SerializeField] private Transform dailyItemViewSpawnPos;
    [SerializeField] private List<DailyItemView> list = new List<DailyItemView>();

    [SerializeField] private Text totalRewardCountText;
    [SerializeField] private GameObject GetRewardsBtn;

    [SerializeField] private Image rewardButtonStatus;
    [SerializeField] private Sprite hasRewards;
    [SerializeField] private Sprite haventRewards;
    public void InitView()
    {
        List<DailyScrObj> dailyListScrObj = DailyCnt.GetCurrentDailyList();
        totalRewardCountText.text = DailyCnt.GetTotalDailyReward() + "";
        foreach (var item in dailyListScrObj)
        {
            DailyItemView newItem = Instantiate(dailyItemViewPB,dailyItemViewSpawnPos);
            newItem.InitView(item);
            list.Add(newItem);
        }

        if (DailyCnt.GetTotalDailyReward() > 0)
        {
            rewardButtonStatus.sprite = hasRewards;
        }
        else
        {
            rewardButtonStatus.sprite = haventRewards;
        }
    }

    public void UpdateView()
    {
        foreach (var item in list)
        {
            Destroy(item.gameObject);
        }
        list.Clear();
        InitView();
    }

    public void GetRewards()
    {
        DailyCnt.GetDailyReward();
        UpdateView();
    }

    public void TestAdd(int id)
    {
        DailyCnt.AddPointToDailyItemComplete(id,1);
    }
}
