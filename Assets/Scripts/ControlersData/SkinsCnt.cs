using System.Collections.Generic;
using ScriptableObjects.SkinsSO;
using UnityEngine;

namespace ControlersData
{
    public class SkinsCnt
    {
        public delegate void AccountHandler();
        public static event AccountHandler SetCurrentSkinEvent;
        
        private static SkinListScrObj SkinListSO = Resources.Load<SkinListScrObj>("ScriptableObjects/SkinsSO/SkinlListSO");
        
        public static bool SkinIsOpened(int id)
        {
            SkinListSO.Load();
            return SkinListSO.OpenedSkinIdList.Contains(id);
        }
        public static SkinScrObj GetCurrentSkin()
        {
            SkinListSO.Load();
            return SkinListSO.list[SkinListSO.CurrentSkinId];
        }
        public static int GetCurrentSkinID()
        {
            SkinListSO.Load();
            return SkinListSO.CurrentSkinId;
        }
    
        public static int GetSkinCount()
        {
            SkinListSO.Load();
            return SkinListSO.list.Count;
        }
    
        public static void SetCurrentSkin(int id)
        {
            SkinListSO.Load();
            if (id < SkinListSO.list.Count)
            {
                SkinListSO.CurrentSkinId = id;
                SkinListSO.Save();
                SetCurrentSkinEvent?.Invoke();
            }
        }
    
        public static void OpenSkin(int id)
        {
            SkinListSO.Load();
            if (!SkinListSO.OpenedSkinIdList.Contains(id))
            {
                SkinListSO.OpenedSkinIdList.Add(id);
                SkinListSO.Save();
            }
        }

        public static SkinListScrObj GetList()
        {
            SkinListSO.Load();
            return SkinListSO;
        }

        public static List<SkinScrObj> GetListOfClosesSkins()
        {
            SkinListSO.Load();
            List<SkinScrObj> closesSkins = new List<SkinScrObj>();
            foreach (var item in SkinListSO.list)
            {
               if(!SkinListSO.OpenedSkinIdList.Contains(item.id)) closesSkins.Add(item);
            }

            return closesSkins;
        }

        public static int GetSkinCost()
        {
            SkinListSO.Load();
            return SkinListSO.SkinCost;
        }
    }
}