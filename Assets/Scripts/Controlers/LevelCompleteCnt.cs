using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SessionCore;

public class LevelCompleteCnt : MonoBehaviour
{
   private int coloredCount;
   private CompleteLevelDel completeLevelDel;
   public void InitControler(int coloredCount, CompleteLevelDel completeLevelDel)
   {
      this.completeLevelDel = completeLevelDel;
      this.coloredCount = coloredCount;
   }
   public void CheckComposeStates(List<BoxCom> boxComs)
   {
      int composeCount = 0;
      foreach (var item in boxComs)
      {
         if (item.CheckComposeState()) composeCount++;
      }

      if (coloredCount == composeCount)
      {
         Debug.Log("LevelComplete");
         
         completeLevelDel?.Invoke();
      }
   }
}
