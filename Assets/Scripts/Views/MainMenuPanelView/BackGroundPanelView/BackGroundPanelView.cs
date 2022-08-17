using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.BackGroundSO.SkriptsSO;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class BackGroundPanelView : MonoBehaviour
    {
        [SerializeField] private BackGroundItemView backGroundItemViewPB;
        [SerializeField] private Transform backGroundItemViewSpawnPos;
        [SerializeField] private List<BackGroundItemView> list = new List<BackGroundItemView>();
        [SerializeField] private Text backGroundCostText;
        [SerializeField] private GameObject buyRandomBackGroundBtn;
        [SerializeField] private GameObject getCoinsByAds;
        [SerializeField] private GameObject allBought;

        public delegate void SelectBackGroundDel(BackGroundScrObj backGroundScrObj);
        public void InitView()
        {
            BackGroundListScrObj backGroundListScrObj = BackGroundCnt.GetList();
            backGroundCostText.text = "" + BackGroundCnt.GetBackGroundCost();
            
            if (BackGroundCnt.GetListOfClosesBackGrounds().Count == 0)
            {
                buyRandomBackGroundBtn.SetActive(false);
                allBought.SetActive(true);
            }

            if (CoinsCnt.GetCoinsCount() < BackGroundCnt.GetBackGroundCost())
            {
                getCoinsByAds.SetActive(true);
            }
            else
            {
                getCoinsByAds.SetActive(false);
            }
            
            foreach (var item in backGroundListScrObj.list)
            {
                BackGroundItemView newItem = Instantiate(backGroundItemViewPB,backGroundItemViewSpawnPos);
                newItem.InitView(item, SelectBackGround);
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

        public void SelectBackGround(BackGroundScrObj backGroundScrObj)
        {
            if (BackGroundCnt.GetCurrentBackGround().id != backGroundScrObj.id && BackGroundCnt.BackGroundIsOpened(backGroundScrObj.id))
            {
                BackGroundCnt.SetCurrentBackGround(backGroundScrObj.id);
                UpdateView();
            }
            
        }
        
        public void BuyRandomBackGround()
        {
            if (CoinsCnt.EnothCoins(BackGroundCnt.GetBackGroundCost()))
            {
                List<BackGroundScrObj> backGroundListScrObj = BackGroundCnt.GetListOfClosesBackGrounds();
                CoinsCnt.SubtractCoins(BackGroundCnt.GetBackGroundCost());
                BackGroundScrObj randBackGround = backGroundListScrObj[Random.Range(0, backGroundListScrObj.Count)];
                BackGroundCnt.OpenBackGround(randBackGround.id);
                UpdateView();
            }
        }
    }
}