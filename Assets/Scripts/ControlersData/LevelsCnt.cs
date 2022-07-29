using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.LevelsSO;
using UnityEngine;

public class LevelsCnt
{
    private static LevelListScrObj LevelListSO = Resources.Load<LevelListScrObj>("ScriptableObjects/LevelsSO/LevelListSO");
    
    public static bool LevelIsOpened(int id)
    {
        LevelListSO.Load();
        return LevelListSO.OpenedLevelIdList.Contains(id);
    }
    public static LevelScrObj GetCurrentLevel()
    {
        LevelListSO.Load();
        return LevelListSO.list[LevelListSO.CurrentLevelId];
    }
    public static int GetCurrentLevelID()
    {
        LevelListSO.Load();
        return LevelListSO.CurrentLevelId;
    }
    
    public static int GetLevelCount()
    {
        LevelListSO.Load();
        return LevelListSO.list.Count;
    }
    
    public static void SetCurrentLevel(int id)
    {
        LevelListSO.Load();
        if (id < LevelListSO.list.Count)
        {
            LevelListSO.CurrentLevelId = id;
            LevelListSO.Save();
        }
    }
    
    public static void OpenLevel(int id)
    {
        LevelListSO.Load();
        if (!LevelListSO.OpenedLevelIdList.Contains(id))
        {
            LevelListSO.OpenedLevelIdList.Add(id);
            LevelListSO.Save();
        }
    }
    
    public static List<LevelScrObj> GetSessionLevelsFromPage(int pageId)
    {
        LevelListSO.Load();
        int itemOnPage = 9;
        List<LevelScrObj> list = new List<LevelScrObj>();
        for (int i = 0 + itemOnPage * pageId; i <itemOnPage + itemOnPage * pageId; i++)
        {
            if (i < LevelListSO.list.Count)
            {
                list.Add(LevelListSO.list[i]);
            }
        }
           
        return list;
    }
    
}
