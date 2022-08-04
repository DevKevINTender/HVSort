using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ScriptableObjects.ProgressSO.ScriptsSO
{
    [CreateAssetMenu(fileName = "ProgressListSO", menuName = "SrcObj/ new ProgressListSO", order = 0)]
    public class ProgressListScrObj : ScriptableObject
    {
        public string SavePath;
        public  List<ProgressScrObj> list = new List<ProgressScrObj>();
        
        [ContextMenu("Save")]
        public void Save()
        {
            ProgressListSave newProgressListSave = new ProgressListSave();

            for (int i = 0; i < list.Count; i++)
            {
                newProgressListSave.list.Add(new ProgressSave());
                newProgressListSave.list[i].isCompleted = list[i].isCompleted;
                newProgressListSave.list[i].isGetReward = list[i].isGetReward;
            }
            
            string saveData = JsonUtility.ToJson(newProgressListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            ProgressListSave newProgressListSave = new ProgressListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newProgressListSave);
                
                for (int i = 0; i < newProgressListSave.list.Count; i++)
                {
                    list[i].isCompleted =  newProgressListSave.list[i].isCompleted;
                    list[i].isGetReward = newProgressListSave.list[i].isGetReward;
                    list[i].id = i;
                }

                file.Close();
            }
        }
        [ContextMenu("ResetData")]
        public void ResetData()
        {
            Load();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].isCompleted =  false;
                list[i].isGetReward = false;
            }
            Save();
        }
    }
    
    [Serializable]
    public class ProgressListSave
    {
        public List<ProgressSave> list = new List<ProgressSave>();
    }
    
    [Serializable]
    public class ProgressSave
    {
        public bool isCompleted;
        public bool isGetReward;
    }
}