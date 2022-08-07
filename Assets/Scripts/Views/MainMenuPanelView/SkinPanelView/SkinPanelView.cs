using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.SkinsSO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkinPanelView : MonoBehaviour
{
    [SerializeField] private SkinItemView skinItemViewPB;
    [SerializeField] private Transform skinItemViewSpawnPos;
    [SerializeField] private List<SkinItemView> list = new List<SkinItemView>();
    [SerializeField] private int SkinCost;
    [SerializeField] private Text skiinCostText;
    [SerializeField] private GameObject buyRandomSkinBtn;
    [SerializeField] private GameObject getCoinsByAds;
    [SerializeField] private GameObject allBought;

    public delegate void SelectSkinDel(SkinScrObj skinScrObj);
    public void InitView()
    {
        SkinListScrObj skinListScrObj = SkinsCnt.GetList();
        skiinCostText.text = "" + SkinCost;
        
        if (SkinsCnt.GetListOfClosesSkins().Count == 0)
        {
            buyRandomSkinBtn.SetActive(false);
            getCoinsByAds.SetActive(false);
            allBought.SetActive(true);
        }

        foreach (var item in skinListScrObj.list)
        {
            SkinItemView newItem = Instantiate(skinItemViewPB,skinItemViewSpawnPos);
            newItem.InitView(item, SelectSkin);
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

    public void SelectSkin(SkinScrObj skinScrObj)
    {
        if (SkinsCnt.GetCurrentSkin().id != skinScrObj.id && SkinsCnt.SkinIsOpened(skinScrObj.id))
        {
            SkinsCnt.SetCurrentSkin(skinScrObj.id);
            UpdateView();
        }
        
    }
    
    public void BuyRandomSkin()
    {
        if (CoinsCnt.EnothCoins(SkinCost))
        {
            List<SkinScrObj> skinListScrObj = SkinsCnt.GetListOfClosesSkins();
            CoinsCnt.SubtractCoins(SkinCost);
            SkinScrObj randSkin = skinListScrObj[Random.Range(0, skinListScrObj.Count)];
            SkinsCnt.OpenSkin(randSkin.id);
            UpdateView();
        }
    }
}
