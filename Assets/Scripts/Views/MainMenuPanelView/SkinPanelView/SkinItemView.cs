using System;
using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.SkinsSO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using static SkinPanelView;
public class SkinItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform itemPos;
    [SerializeField] private Image statusItem;
    [SerializeField] private Sprite closedItem;
    [SerializeField] private Sprite selectedItem;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private GameObject secretSkin;

    private SkinScrObj skinScrObj;

    public SelectSkinDel SelectSkinDel;
    public void InitView(SkinScrObj skinScrObj, SelectSkinDel SelectSkinDel)
    {
        this.skinScrObj = skinScrObj;
        this.SelectSkinDel = SelectSkinDel;
        
        if (SkinsCnt.SkinIsOpened(skinScrObj.id))
        {
            Instantiate(skinScrObj.skinUI, itemPos);
            statusItem.sprite = openedSprite;
            if (SkinsCnt.GetCurrentSkin().id == skinScrObj.id)
            {
                statusItem.sprite = selectedItem;
            }
            secretSkin.SetActive(false);
        }
        else
        {
            statusItem.sprite = closedItem;
            secretSkin.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectSkinDel?.Invoke(skinScrObj);
    }
}
