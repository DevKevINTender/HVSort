using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ScriptableObjects.SkinsSO
{
    [CreateAssetMenu(fileName = "SkinlListSO", menuName = "SrcObj/ new SkinlListSO", order = 0)]
    public class SkinListScrObj : ScriptableObject
    {
        public string SavePath;
        //Save
        public int CurrentSkinId;
        public List<int> OpenedSkinIdList = new List<int>();
        public List<SkinScrObj> list = new List<SkinScrObj>();
        
        [ContextMenu("Save")]
        public void Save()
        {
            SkinListSave newSkinListSave = new SkinListSave();
            newSkinListSave.CurrentSkinId = CurrentSkinId;
            newSkinListSave.OpenedSkinIdList = OpenedSkinIdList;

            string saveData = JsonUtility.ToJson(newSkinListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            SkinListSave newSkinListSave = new SkinListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newSkinListSave);
               
                
                CurrentSkinId = newSkinListSave.CurrentSkinId;
                OpenedSkinIdList = newSkinListSave.OpenedSkinIdList;

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].id = i;
                }

                file.Close();
            }
        }
    }
    
    public class SkinListSave
    {
        public int CurrentSkinId;
        public List<int> OpenedSkinIdList = new List<int>();
        
    }
}