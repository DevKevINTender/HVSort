using System.Collections.Generic;
using ScriptableObjects.BackGroundSO.SkriptsSO;
using UnityEngine;

namespace ControlersData
{
    public class BackGroundCnt
    {
        public delegate void AccountHandler();
        public static event AccountHandler SetCurrentBackGroundEvent;

        private static BackGroundListScrObj BackGroundListSO = Resources.Load<BackGroundListScrObj>("ScriptableObjects/BackGroundSO/BackGroundListSO");
        
        public static bool BackGroundIsOpened(int id)
        {
            BackGroundListSO.Load();
            return BackGroundListSO.OpenedBackGroundIdList.Contains(id);
        }
        public static BackGroundScrObj GetCurrentBackGround()
        {
            BackGroundListSO.Load();
            return BackGroundListSO.list[BackGroundListSO.CurrentBackGroundId];
        }
        public static int GetCurrentBackGroundID()
        {
            BackGroundListSO.Load();
            return BackGroundListSO.CurrentBackGroundId;
        }
    
        public static int GetBackGroundCount()
        {
            BackGroundListSO.Load();
            return BackGroundListSO.list.Count;
        }
    
        public static void SetCurrentBackGround(int id)
        {
            BackGroundListSO.Load();
            if (id < BackGroundListSO.list.Count)
            {
                BackGroundListSO.CurrentBackGroundId = id;
                BackGroundListSO.Save();
                SetCurrentBackGroundEvent?.Invoke();
            }
        }
    
        public static void OpenBackGround(int id)
        {
            BackGroundListSO.Load();
            if (!BackGroundListSO.OpenedBackGroundIdList.Contains(id))
            {
                BackGroundListSO.OpenedBackGroundIdList.Add(id);
                BackGroundListSO.Save();
            }
        }

        public static BackGroundListScrObj GetList()
        {
            BackGroundListSO.Load();
            return BackGroundListSO;
        }

        public static List<BackGroundScrObj> GetListOfClosesBackGrounds()
        {
            BackGroundListSO.Load();
            List<BackGroundScrObj> closedBackGrounds = new List<BackGroundScrObj>();
            foreach (var item in BackGroundListSO.list)
            {
                if(!BackGroundListSO.OpenedBackGroundIdList.Contains(item.id)) closedBackGrounds.Add(item);
            }

            return closedBackGrounds;
        }
    }
}