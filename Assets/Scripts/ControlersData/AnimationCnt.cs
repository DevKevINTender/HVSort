using System.Collections.Generic;
using ScriptableObjects.AnimationsSO.SkriptsSO;
using UnityEngine;

namespace ControlersData
{
    public class AnimationCnt
    {
        public delegate void AccountHandler();
        public static event AccountHandler SetCurrentAnimationEvent;

        private static AnimationListScrObj AnimationListSO = Resources.Load<AnimationListScrObj>("ScriptableObjects/AnimationsSO/AnimationListSO");
        
        public static bool AnimationIsOpened(int id)
        {
            AnimationListSO.Load();
            return AnimationListSO.OpenedAnimationIdList.Contains(id);
        }
        public static AnimationScrObj GetCurrentAnimation()
        {
            AnimationListSO.Load();
            return AnimationListSO.list[AnimationListSO.CurrentAnimationId];
        }
        public static int GetCurrentAnimationID()
        {
            AnimationListSO.Load();
            return AnimationListSO.CurrentAnimationId;
        }
    
        public static int GetAnimationCount()
        {
            AnimationListSO.Load();
            return AnimationListSO.list.Count;
        }
    
        public static void SetCurrentAnimation(int id)
        {
            AnimationListSO.Load();
            if (id < AnimationListSO.list.Count)
            {
                AnimationListSO.CurrentAnimationId = id;
                AnimationListSO.Save();
                SetCurrentAnimationEvent?.Invoke();
            }
        }
    
        public static void OpenAnimation(int id)
        {
            AnimationListSO.Load();
            if (!AnimationListSO.OpenedAnimationIdList.Contains(id))
            {
                AnimationListSO.OpenedAnimationIdList.Add(id);
                AnimationListSO.Save();
            }
        }

        public static AnimationListScrObj GetList()
        {
            AnimationListSO.Load();
            return AnimationListSO;
        }

        public static List<AnimationScrObj> GetListOfClosesAnimations()
        {
            AnimationListSO.Load();
            List<AnimationScrObj> closedAnimation = new List<AnimationScrObj>();
            foreach (var item in AnimationListSO.list)
            {
                if(!AnimationListSO.OpenedAnimationIdList.Contains(item.id)) closedAnimation.Add(item);
            }

            return closedAnimation;
        }
        
        public static int GetAnimationCost()
        {
            AnimationListSO.Load();
            return AnimationListSO.AnimationCost;
        }
    }
}