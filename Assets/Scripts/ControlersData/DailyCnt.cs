using System;
using System.Collections.Generic;
using ScriptableObjects.DailySo.ScriptsSO;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ControlersData
{
    public class DailyCnt
    {
        private static DailyListScrObj DailyListSO = Resources.Load<DailyListScrObj>("ScriptableObjects/DailySO/DailyListSO");
        public static DateTime lastGetDaily;
        public static List<DateTime> updateTimeList = new List<DateTime>() {DateTime.Parse("00:00:00"),DateTime.Parse("12:00:00"),DateTime.Parse("18:00:00")};
        
        public delegate void AccountHandler();
        public static event AccountHandler CompleteDailyEvent;
        
        public static void InitControler()
        {
            DailyListSO.Save();
            GetCurrentDailyList();
        }

        public static List<DailyScrObj> GetCurrentDailyList()
        {
            if (CheckCurrentDaily())
            {
                ClearCurrentDailyList();
                CreateCurrentDailyList();
            }
            return DailyListSO.currentList;
        }
        
        public static bool CheckCurrentDaily()
        {
            DailyListSO.Load();
            bool isNeedUpdate = false;
            
            if(DailyListSO.currentList.Count == 0) return true;
            
            lastGetDaily = DateTime.Parse(DailyListSO.lastGetDaily);
           
            int currentSegment = GetCurrentSegmentId();
           

            if (currentSegment != DailyListSO.currentSegment)
            {
                Debug.Log("true");
                isNeedUpdate = true;
            }
            else
            {
               
                if (lastGetDaily.Date != DateTime.Now.Date)
                {
                    isNeedUpdate = true;
                }
            }
            DailyListSO.currentSegment = currentSegment;
            DailyListSO.lastGetDaily = DateTime.Now.ToString();
            DailyListSO.Save();
            
            return isNeedUpdate;
        }
        
        public static int  GetCurrentSegmentId()
        {
            DailyListSO.Load();
            int currentSegment = 0;
            
            for (int i = 0; i < updateTimeList.Count; i++)
            {
                if (DateTime.Now.TimeOfDay > updateTimeList[i].TimeOfDay)
                {
                    currentSegment = i+1;
                }
            }

            return currentSegment;
        }
        
        public static void AddPointToDailyItemComplete(int id, int points)
        {
            DailyListSO.Load();
            foreach (var item in DailyListSO.currentList)
            {
                if (item.id == id && !item.isCompleted)
                {
                    item.currentPoints += points;
                    if (item.currentPoints >= item.completedPoints)
                    {
                        item.isCompleted = true;
                        DailyListSO.Save();
                        CompleteDailyEvent?.Invoke();
                    }
                }
            }
            DailyListSO.Save();
        }

        public static void GetDailyReward()
        {
            DailyListSO.Load();
            foreach (var item in DailyListSO.currentList)
            {
                if (item.isCompleted && !item.isGetReward)
                {
                    CoinsCnt.AddCoins(item.reward);
                    item.isGetReward = true;
                }
            }
        }

        public static int GetTotalDailyReward()
        {
            DailyListSO.Load();
            int totalReward = 0;
            foreach (var item in DailyListSO.currentList)
            {
                if (item.isCompleted && !item.isGetReward)
                {
                    totalReward += item.reward;
                }
            }
            return totalReward;
        }
        
        public static void CreateCurrentDailyList()
        {
            DailyListSO.Load();
            List<DailyScrObj> randList = new List<DailyScrObj>();
            foreach (var item in DailyListSO.list)
            {
                randList.Add(item);
            }
            List<DailyScrObj> newCurrentDailyList = new List<DailyScrObj>();
            for (int i = 0; i < 3; i++)
            {
                int rand = Random.Range(0, randList.Count);
                newCurrentDailyList.Add(randList[rand]);
                randList.RemoveAt(rand);
            }

            DailyListSO.currentList = newCurrentDailyList;
            DailyListSO.currentSegment = GetCurrentSegmentId();
            DailyListSO.lastGetDaily = DateTime.Now.ToString();
            DailyListSO.Save();
        }

        public static void ClearCurrentDailyList()
        {
            DailyListSO.Load();
            foreach (var item in DailyListSO.currentList)
            {
                item.currentPoints = 0;
                item.isCompleted = false;
                item.isGetReward = false;
            }
            DailyListSO.currentList.Clear();
            DailyListSO.Save();
        }

       
    }
}