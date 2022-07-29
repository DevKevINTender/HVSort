using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ScriptableObjects.BackGroundSO.SkriptsSO
{
    [CreateAssetMenu(fileName = "BackGroundListSO", menuName = "SrcObj/ new BackGroundListSO", order = 0)]
    public class BackGroundListScrObj : ScriptableObject
    {
        public string SavePath;
        //Save
        public int CurrentBackGroundId;
        public List<int> OpenedBackGroundIdList = new List<int>();
        public List<BackGroundScrObj> list = new List<BackGroundScrObj>();
        
        [ContextMenu("Save")]
        public void Save()
        {
            BackGroundListSave newBackGroundListSave = new BackGroundListSave();
            newBackGroundListSave.CurrentBackGroundId = CurrentBackGroundId;
            newBackGroundListSave.OpenedBackGroundIdList = OpenedBackGroundIdList;

            string saveData = JsonUtility.ToJson(newBackGroundListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            BackGroundListSave newBackGroundListSave = new BackGroundListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newBackGroundListSave);
               
                
                CurrentBackGroundId = newBackGroundListSave.CurrentBackGroundId;
                OpenedBackGroundIdList = newBackGroundListSave.OpenedBackGroundIdList;

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].id = i;
                }

                file.Close();
            }
        }
    }
    
    public class BackGroundListSave
    {
        public int CurrentBackGroundId;
        public List<int> OpenedBackGroundIdList = new List<int>();
        
    }
}