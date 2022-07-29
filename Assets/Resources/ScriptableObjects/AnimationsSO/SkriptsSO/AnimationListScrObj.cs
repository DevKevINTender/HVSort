using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ScriptableObjects.BackGroundSO.SkriptsSO;
using UnityEngine;

namespace ScriptableObjects.AnimationsSO.SkriptsSO
{
    [CreateAssetMenu(fileName = "AnimationListSO", menuName = "SrcObj/ new AnimationListSO", order = 0)]
    public class AnimationListScrObj : ScriptableObject
    {
        public string SavePath;
        //Save
        public int CurrentAnimationId;
        public List<int> OpenedAnimationIdList = new List<int>();
        public List<AnimationScrObj> list = new List<AnimationScrObj>();
        
        [ContextMenu("Save")]
        public void Save()
        {
            AnimationListSave newAnimationListSave = new AnimationListSave();
            newAnimationListSave.CurrentAnimationId = CurrentAnimationId;
            newAnimationListSave.OpenedAnimationIdList = OpenedAnimationIdList;

            string saveData = JsonUtility.ToJson(newAnimationListSave, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath+"/"+SavePath));
            bf.Serialize(file, saveData);
            file.Close();
        }
        
        [ContextMenu("Load")]
        public void Load()
        {
            AnimationListSave newAnimationListSave = new AnimationListSave();
            if (File.Exists(string.Concat(Application.persistentDataPath,"/",SavePath)))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath,"/",SavePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), newAnimationListSave);
               
                
                CurrentAnimationId = newAnimationListSave.CurrentAnimationId;
                OpenedAnimationIdList = newAnimationListSave.OpenedAnimationIdList;

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].id = i;
                }

                file.Close();
            }
        }
    }
    
    public class AnimationListSave
    {
        public int CurrentAnimationId;
        public List<int> OpenedAnimationIdList = new List<int>();
        
    }
}