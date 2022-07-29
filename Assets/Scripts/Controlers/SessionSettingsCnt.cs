using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.LevelsSO;
using UnityEngine;

public class SessionSettingsCnt : MonoBehaviour
{
    public int coloredBoxCount;
    public int freeBoxCount;
    
    public List<BoxCom> boxList;
    public List<BoxCom> activeBoxList;
    public List<BoxCom> extraBoxList;

    public LevelScrObj LevelSO;

    public void InitControler()
    {
        LevelSO = LevelsCnt.GetCurrentLevel();
        coloredBoxCount = LevelSO.coloredBoxCount;
        freeBoxCount = LevelSO.freeBoxCount;
    }
}
