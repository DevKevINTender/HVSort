using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.AnimationsSO.SkriptsSO;
using UnityEngine;
using UnityEngine.UI;

public class AnimationPanelView : MonoBehaviour
{
    [SerializeField] private AnimationItemView animationItemViewPB;
    [SerializeField] private Transform animationItemViewSpawnPos;
    [SerializeField] private List<AnimationItemView> list = new List<AnimationItemView>();
    [SerializeField] private int AnimationCost;
    [SerializeField] private Text animationCostText;
    [SerializeField] private GameObject buyRandomAnimationBtn;
    [SerializeField] private GameObject getCoinsByAds;
    [SerializeField] private GameObject allBought;

    public delegate void SelectAnimationDel(AnimationScrObj animationScrObj);
    public void InitView()
    {
        AnimationListScrObj skinListScrObj = AnimationCnt.GetList();
        animationCostText.text = "" + AnimationCost;
        
        if (AnimationCnt.GetListOfClosesAnimations().Count == 0)
        {
            buyRandomAnimationBtn.SetActive(false);
            getCoinsByAds.SetActive(false);
            allBought.SetActive(true);
        }

        foreach (var item in skinListScrObj.list)
        {
            AnimationItemView newItem = Instantiate(animationItemViewPB,animationItemViewSpawnPos);
            newItem.InitView(item, SelectAnimation);
            list.Add(newItem);
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

    public void SelectAnimation(AnimationScrObj animationScrObj)
    {
        if (AnimationCnt.GetCurrentAnimation().id != animationScrObj.id && AnimationCnt.AnimationIsOpened(animationScrObj.id))
        {
            AnimationCnt.SetCurrentAnimation(animationScrObj.id);
            UpdateView();
        }
        
    }
    
    public void BuyRandomAnimation()
    {
        if (CoinsCnt.EnothCoins(AnimationCost))
        {
            List<AnimationScrObj> animationListScrObj = AnimationCnt.GetListOfClosesAnimations();
            CoinsCnt.SubtractCoins(AnimationCost);
            AnimationScrObj randAnimation= animationListScrObj[Random.Range(0, animationListScrObj.Count)];
            AnimationCnt.OpenAnimation(randAnimation.id);
            UpdateView();
        }
    }
}
