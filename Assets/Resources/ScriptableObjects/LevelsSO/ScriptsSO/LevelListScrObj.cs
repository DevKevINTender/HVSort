using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ScriptableObjects.LevelsSO
{
    [CreateAssetMenu(fileName = "LevelListSO", menuName = "SrcObj/ new LevelListSO", order = 0)]
    public class LevelListScrObj : ScriptableObject
    {
        public string SavePath;
        //Save
        public int CurrentLevelId;
        public List<int> OpenedLevelIdList = new List<int>();
        public List<LevelScrObj> list = new List<LevelScrObj>();
        
        [ContextMenu("Save")]
        public void Save()
        {
            LevelListSave newLevelListSave = new LevelListSave();
            newLevelListSave.CurrentSessionLevelId = CurrentLevelId;
            newLevelListSave.OpenedSessionLevelIdList = OpenedLevelIdList;

            string saveData = JsonUtility.ToJson(newLevelListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            LevelListSave newLevelListSave = new LevelListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newLevelListSave);
               
                
                CurrentLevelId = newLevelListSave.CurrentSessionLevelId;
                OpenedLevelIdList = newLevelListSave.OpenedSessionLevelIdList;

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].id = i;
                }

                file.Close();
            }
        }
        [ContextMenu("ResetData")]
        public void ResetData()
        {
            Load();
            CurrentLevelId = 0;
            OpenedLevelIdList.Clear();
            OpenedLevelIdList.Add(0);
            Save();
        }
        [ContextMenu("OpenAll")]
        public void OpenAll()
        {
            Load();
            for (int i = 0; i < list.Count; i++)
            {
                if(!OpenedLevelIdList.Contains(i)) OpenedLevelIdList.Add(i);
            }
            Save();
        }
        
    }
    
    public class LevelListSave
    {
        public int CurrentSessionLevelId;
        public List<int> OpenedSessionLevelIdList = new List<int>();
        
    }
}