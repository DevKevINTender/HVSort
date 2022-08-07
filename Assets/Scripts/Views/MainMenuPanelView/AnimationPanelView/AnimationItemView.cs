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
    [SerializeField] private GameObject itemPos;
    [SerializeField] private Image statusItem;
    [SerializeField] private Sprite closedItem;
    [SerializeField] private Sprite selectedItem;
    [SerializeField] private Sprite openedSprite;
    [SerializeField] private GameObject secretAnimation;
    
    [SerializeField] private Animation hvAnimation;
    [SerializeField] private SpriteRenderer hvHeadSprite;
    
    private AnimationScrObj animationScrObj;

    public SelectAnimationDel SelectAnimationDel;
    public void InitView(AnimationScrObj animationScrObj, SelectAnimationDel SelectAnimationDel)
    {
        this.animationScrObj = animationScrObj;
        this.SelectAnimationDel = SelectAnimationDel;
        
        if (AnimationCnt.AnimationIsOpened(animationScrObj.id))
        {
            SetAnimation(animationScrObj);
            SetSkin();
            statusItem.sprite = openedSprite;
            if (AnimationCnt.GetCurrentAnimation().id == animationScrObj.id)
            {
                statusItem.sprite = selectedItem;
            }
            secretAnimation.SetActive(false);
            itemPos.SetActive(true);
        }
        else
        {
            statusItem.sprite = closedItem;
            secretAnimation.SetActive(true);
            itemPos.SetActive(false);
        }
    }
    
    
    public void SetSkin()
    {
        hvHeadSprite.sprite = SkinsCnt.GetCurrentSkin().skinHeadSprite;
    }

    public void SetAnimation(AnimationScrObj animationScrObj)
    {
        hvAnimation.clip = animationScrObj.AnimationItem;
        hvAnimation.Play();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectAnimationDel?.Invoke(animationScrObj);
    }
}
