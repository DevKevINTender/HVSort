using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ScriptableObjects.LevelsSO;
using UnityEngine;

namespace ScriptableObjects.DailySo.ScriptsSO
{
    [CreateAssetMenu(fileName = "DailyListSO", menuName = "SrcObj/ new DailyListSO", order = 0)]
    public class DailyListScrObj : ScriptableObject
    {
        public string SavePath;
        public List<DailyScrObj> list = new List<DailyScrObj>();
        public List<DailyScrObj> currentList = new List<DailyScrObj>();
        public string lastGetDaily;
        public int currentSegment;
        
        
        [ContextMenu("Save")]
        public void Save()
        {
            DailyListSave newDailyListSave = new DailyListSave();
            newDailyListSave.lastGetDaily = lastGetDaily;

            for (int i = 0; i < currentList.Count; i++)
            {
                newDailyListSave.currentList.Add(new DailySave());
                newDailyListSave.currentList[i].currentPoints = currentList[i].currentPoints;
                newDailyListSave.currentList[i].isCompleted = currentList[i].isCompleted;
                newDailyListSave.currentList[i].isGetReward = currentList[i].isGetReward;
                newDailyListSave.currentList[i].reward = currentList[i].reward;
                newDailyListSave.currentList[i].completedPoints = currentList[i].completedPoints;
            }

            string saveData = JsonUtility.ToJson(newDailyListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            DailyListSave newDailyListSave = new DailyListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newDailyListSave);
                
                lastGetDaily = newDailyListSave.lastGetDaily;
                
                for (int i = 0; i < newDailyListSave.currentList.Count; i++)
                {
                    currentList[i].currentPoints = newDailyListSave.currentList[i].currentPoints;
                    currentList[i].isCompleted =  newDailyListSave.currentList[i].isCompleted;
                    currentList[i].isGetReward = newDailyListSave.currentList[i].isGetReward;
                    currentList[i].reward = newDailyListSave.currentList[i].reward;
                    currentList[i].completedPoints = newDailyListSave.currentList[i].completedPoints;
                }
                
                file.Close();
            }
        }
        [ContextMenu("ResetData")]
        public void ResetData()
        {
            Load();
            for (int i = 0; i < currentList.Count; i++)
            {
                list[i].currentPoints = 0;
                list[i].isCompleted =  false;
                list[i].isGetReward = false;
                list[i].completedPoints = 0;
                list[i].reward = 0;
            }
            currentList.Clear();
            Save();
        }
    }
    
    [Serializable]
    public class DailyListSave
    {
        public List<DailySave> currentList = new List<DailySave>();
        public string lastGetDaily;
    }

    [Serializable]
    public class DailySave
    {
        public int reward;
        public int completedPoints;
        public int currentPoints;
        public bool isCompleted;
        public bool isGetReward;
    }
}