using ScriptableObjects.ProgressSO.ScriptsSO;
using UnityEngine;

namespace ControlersData
{
    public class ProgressCnt
    {
        private static ProgressListScrObj ProgressListSO = Resources.Load<ProgressListScrObj>("ScriptableObjects/ProgressSO/ProgressListSO");
        public delegate void AccountHandler();
        public static event AccountHandler ChangeProgressStatusEvent;
        public static ProgressScrObj GetCurrentProgress()
        {
            ProgressListSO.Load();
            ProgressScrObj itemById = null;
            foreach (var item in ProgressListSO.list)
            {
                if(item.isCompleted && !item.isGetReward) return item;
                if(!item.isGetReward) return item;
            }

            return itemById;
        }

        public static void CheckCurrentProgress()
        {
            ProgressListSO.Load();
            int maxLevel = LevelsCnt.GetCurrentLevelID();
            foreach (var item in ProgressListSO.list)
            {
                if (!item.isCompleted && item.needLevel <= maxLevel)
                {
                    item.isCompleted = true;
                }
            }
            ProgressListSO.Save();
            ChangeProgressStatusEvent?.Invoke();
        }

        public static void GetProgressReward(int id)
        {
            ProgressListSO.Load();
            if(id >= ProgressListSO.list.Count) return;
            if (ProgressListSO.list[id].isCompleted && !ProgressListSO.list[id].isGetReward)
            {
                CoinsCnt.AddCoins(ProgressListSO.list[id].reward);
                ProgressListSO.list[id].isGetReward = true;
                ProgressListSO.Save();
                CheckCurrentProgress();
            }
        }
    }
}