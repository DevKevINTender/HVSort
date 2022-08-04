using System.Collections;
using System.Collections.Generic;
using ControlersData;
using UnityEngine;

public class FullCom : MonoBehaviour
{
    public void SetSkih()
    {
        
    }

    public void SetAnimation()
    {
        
    }
    
    public void Start()
    {
        SkinsCnt.SetCurrentSkinEvent += SetSkih;
        AnimationCnt.SetCurrentAnimationEvent += SetAnimation;
    }

    public void OnDestroy()
    {
        SkinsCnt.SetCurrentSkinEvent -= SetSkih;
        AnimationCnt.SetCurrentAnimationEvent -= SetAnimation;    }
}
