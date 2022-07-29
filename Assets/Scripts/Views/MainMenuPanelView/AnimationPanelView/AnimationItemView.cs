using System.Collections;
using System.Collections.Generic;
using ControlersData;
using ScriptableObjects.AnimationsSO.SkriptsSO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static AnimationPanelView;

public class AnimationItemView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform itemPos;
    [SerializeField] private Image statusItem;
    [SerializeField] private Sprite closedItem;
    [SerializeField] private Sprite selectedItem;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private GameObject secretAnimation;

    private AnimationScrObj animationScrObj;

    public SelectAnimationDel SelectAnimationDel;
    public void InitView(AnimationScrObj animationScrObj, SelectAnimationDel SelectAnimationDel)
    {
        this.animationScrObj = animationScrObj;
        this.SelectAnimationDel = SelectAnimationDel;
        
        if (AnimationCnt.AnimationIsOpened(animationScrObj.id))
        {
            //Instantiate(animationScrObj.AnimationItem, itemPos);
            statusItem.sprite = openedSprite;
            if (SkinsCnt.GetCurrentSkin().id == animationScrObj.id)
            {
                statusItem.sprite = selectedItem;
            }
            secretAnimation.SetActive(false);
        }
        else
        {
            statusItem.sprite = closedItem;
            secretAnimation.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectAnimationDel?.Invoke(animationScrObj);
    }
}
