using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;

public class FullCom : MonoBehaviour
{
    [SerializeField] private Animation hvAnimation;
    [SerializeField] private SpriteRenderer hvHeadSprite;

    public void Start()
    {
        SetSkin();
        SetAnimation();
    }
    
    public void SetSkin()
    {
        hvHeadSprite.sprite = SkinsCnt.GetCurrentSkin().skinHeadSprite;
    }

    public void SetAnimation()
    {
        hvAnimation.clip = AnimationCnt.GetCurrentAnimation().AnimationItem;
        hvAnimation.Play(hvAnimation.clip.name);
    }
    
    public void Awake()
    {
        SkinsCnt.SetCurrentSkinEvent += SetSkin;
        AnimationCnt.SetCurrentAnimationEvent += SetAnimation;
    }

    public void OnDestroy()
    {
        SkinsCnt.SetCurrentSkinEvent -= SetSkin;
        AnimationCnt.SetCurrentAnimationEvent -= SetAnimation;
        
    }
}
